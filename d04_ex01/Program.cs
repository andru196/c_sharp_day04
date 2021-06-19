using System;
var val = new Microsoft.AspNetCore.Http.DefaultHttpContext();
Console.WriteLine($"Old Response value: {val.Response}");
ChangePrivateNonStaticFieldValue(val, "_response", null);
Console.WriteLine($"New Response value: {val.Response}");

void ChangePrivateNonStaticFieldValue(object Entity, string fieldName, object newValue)
{
    var type = Entity.GetType();
    var fieldInfo = type.GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    if (fieldInfo != null)
    {
        if ((newValue == null && !fieldInfo.FieldType.IsValueType) || fieldInfo.FieldType == newValue.GetType())
        {
            fieldInfo.SetValue(Entity, newValue);
        }
    }
}