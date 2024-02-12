---
title: Points
order: 1
---

# Points

Skybrud.Essentials contains the <code type="Skybrud.Essentials.Maps.Geometry.IPoint, Skybrud.Essentials">IPoint</code> inteface, which describes a point on a map where the point is defined by latitude and longitude.

While you're free to create your own class implementing this interface, Skybrud.Essentials also contains the <code type="Skybrud.Essentials.Maps.Geometry.Point, Skybrud.Essentials">Point</code> class, which implements the interface. Instances of the class can be created as shown below:


```csharp
// Initialize two points by latitude and longitude
IPoint a = new Point(55.708151, 9.536131);
IPoint b = new Point(55.708069, 9.536000);
```

## Distance

While the more complex functionality is handled by the [**Skybrud.Essentials.Maps** package](/skybrud.essentials.maps/), Skybrud.Essentials contains the static <code type="Skybrud.Essentials.Maps.DistanceUtils, Skybrud.Essentials">DistanceUtils</code> utility class.

The class allows you to calculate the distance between two points - eg. as:

```csharp
// Initialize two points by latitude and longitude
IPoint a = new Point(55.708151, 9.536131);
IPoint b = new Point(55.708069, 9.536000);

// Calculate the distance in metres
double distance = DistanceUtils.GetDistance(a, b);
```

The result is measured in metres as it's a [SI-unit](https://en.wikipedia.org/wiki/International_System_of_Units).

Calculations are based on the [equatorial radius of Earth](/skybrud.essentials/reference/maps/earthconstants/), which is defined as `6378136.6` metres as specified by the United States Naval Observatory.

When comparing with various online services, they seem to use <c>6378137</c> metres for the equatorial radius of Earth (no decimals), so if you need to use a specific radius, you may specify it by using a method overload:

```csharp
// Initialize two points by latitude and longitude
IPoint a = new Point(55.708151, 9.536131);
IPoint b = new Point(55.708069, 9.536000);

// Calculate the distance in metres
double distance = DistanceUtils.GetDistance(a, b, 6378137);
```
