using System;
using System.IO;
using System.Reflection;

using SpaCrawler.Framework.Resources;

namespace SpaCrawler.Framework.Utilities
{
    public static class ResourceExtractor
    {
        public static void ExtractEmbeddedResource(string resourceName)
        {
            var resource = GetEmbeddedResource(resourceName);
        }

        private static byte[] GetEmbeddedResource(string resourceName)
        {
            var ass = Assembly.GetAssembly(typeof(EmbeddedResources));
            using (var stream = ass.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found");
                }

                using (var reader = new BinaryReader(stream))
                {
                    return reader.ReadBytes(0); // TODO: Test this
                }
            }
        }
    }
}