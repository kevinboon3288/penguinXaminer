using System.Xml;

namespace XmlReaderModule.Core
{
    public static class XmlFileReader
    {
        public static void ReadAndCheckForDuplicates(string filePath)
        {
            HashSet<string> uniqueContent = new HashSet<string>();
            List<int> duplicateLines = new List<int>();

            using (XmlReader? reader = XmlReader.Create(filePath, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                int lineNumber = 1;

                while (reader.Read())
                {
                    // Only process element nodes that have content
                    if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement())
                    {
                        // Read the element content as a string
                        string? content = reader.ReadInnerXml();

                        // Check for duplicates
                        if (!uniqueContent.Add(content))
                        {
                            // Duplicate found, record the line number
                            duplicateLines.Add(lineNumber);
                        }
                    }

                    // Update the line number
                    lineNumber++;
                }
            }

            // Display the duplicate lines if any
            if (duplicateLines.Count > 0)
            {
                foreach (int line in duplicateLines)
                {
                    Console.WriteLine($"Line {line}");
                }
            }
        }
    }
}
