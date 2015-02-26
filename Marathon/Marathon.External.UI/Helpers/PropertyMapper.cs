using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marathon.External.UI.Helpers
{
    public static class PropertyMapper
    {
        public static TOutput MapMatchingProperties<TInput, TOutput>(TInput input) where TOutput : new()
        {
            return MapMatchingProperties<TInput, TOutput>(input, false);
        }

        public static void MapMatchingProperties<TInput, TOutput>(TInput input, TOutput output) where TOutput : new()
        {
            MapMatchingProperties<TInput, TOutput>(input, output, false);
        }

        public static TOutput MapMatchingProperties<TInput, TOutput>(TInput input, bool mapNullables) where TOutput : new()
        {
            var output = new TOutput();
            MapMatchingProperties<TInput, TOutput>(input, output, mapNullables);
            return output;
        }

        public static void MapMatchingProperties<TInput, TOutput>(TInput input, TOutput output, bool mapNullables)
        {
            var inputType = typeof(TInput);
            var outputType = typeof(TOutput);

            foreach (var inputProperty in inputType.GetProperties())
            {
                var outputProperty = outputType.GetProperty(inputProperty.Name);

                if (outputProperty != null)
                {
                    if (inputProperty.PropertyType == outputProperty.PropertyType)
                    {
                        var inputValue = inputProperty.GetValue(input, null);
                        if (outputProperty.CanWrite)
                            outputProperty.SetValue(output, inputValue, null);
                    }
                    else if (mapNullables)
                    {
                        var inputIsNullable = inputProperty.PropertyType.IsGenericType &&
                                              inputProperty.PropertyType.GetGenericTypeDefinition() ==
                                              typeof(Nullable<>);

                        var outputIsNullable = outputProperty.PropertyType.IsGenericType &&
                                               outputProperty.PropertyType.GetGenericTypeDefinition() ==
                                               typeof(Nullable<>);

                        if (inputIsNullable && !outputIsNullable)
                        {
                            var inputValue = inputProperty.GetValue(input, null);
                            if (inputValue != null)
                            {
                                outputProperty.SetValue(output, inputValue, null);
                            }
                        }

                        if (!inputIsNullable && outputIsNullable)
                        {
                            var inputValue = inputProperty.GetValue(input, null);
                            outputProperty.SetValue(output, inputValue, null);
                        }
                    }
                }
            }
        }
    }
}