module.exports = function(grunt) {

	var path = require('path');

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Get the root path of the project
	var projectRoot = 'src/' + pkg.name + '/';

	// Load the .csproj file (just as clear text)
	var csproj = grunt.file.read(projectRoot + pkg.name + '.csproj');

	var version = csproj.match(/<Version>(.+?)<\/Version>/);

	if (!version) {
		console.error('Unable to determine version from .csproj');
		return;
	}

	version = version[1];

	grunt.initConfig({
		pkg: pkg,
		clean: {
			files: [
				'releases/temp/'
			]
		},
		copy: {
			bacon: {
				files: [
					{
						expand: true,
						cwd: projectRoot + '../',
						src: [
							'LICENSE.html'
						],
						dest: 'releases/temp/'
					},
					{
						expand: true,
						cwd: projectRoot + 'bin/Release/',
						src: [
							'**/*.dll',
							'**/*.xml'
						],
						dest: 'releases/temp/'
					}
				]
			}
		},
		zip: {
			release: {
				cwd: 'releases/temp/',
				src: [
					'releases/temp/**/*.*'
				],
				dest: 'releases/github/' + pkg.name + '.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-contrib-clean');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('dev', ['clean', 'copy', 'zip', 'clean']);

	grunt.registerTask('default', ['dev']);

};