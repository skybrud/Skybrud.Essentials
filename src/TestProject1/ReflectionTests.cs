using System.Linq.Expressions;
using Skybrud.Essentials.Reflection;

namespace TestProject1 {

    [TestClass]
    public class ReflectionTests {

        [TestMethod]
        public void GetMethodInfo() {

            Expression<Func<MyModel, string>> expression = GetExpression<MyModel, string>(x => x.MyMethod());

            var method = ReflectionUtils.GetMethodInfo(expression);

            Assert.AreEqual("MyMethod", method.Name);

        }

        [TestMethod]
        public void GetPropertyInfo() {

            Expression<Func<MyModel, string>> expression = GetExpression<MyModel, string>(x => x.MyProperty);

            var property = ReflectionUtils.GetPropertyInfo(expression);

            Assert.AreEqual("MyProperty", property.Name);

        }

        private Expression<Func<TModel, TProperty>> GetExpression<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression) {
            return expression;
        }

        public class MyModel {

            public string MyProperty { get; set; } = "Hello There";

            public string MyMethod() {
                return "Hello Where";
            }

        }

    }

}