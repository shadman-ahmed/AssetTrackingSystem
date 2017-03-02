using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.DB
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CascadeDeleteAttribute : Attribute { }
}