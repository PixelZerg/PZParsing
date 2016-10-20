using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZParsing.CSharp
{
    public class CSharpParser
    {
        public CSharpParser()
        {
        }

        File file = new File();

        public File ParseFile(string raw)
        {
            try
            {
                file.Usings = ParseUsings(raw);
            }
            catch (CSharpException e)
            {
                file.Errors.Add(e.Message.ToString()+Environment.NewLine+e.InnerException.ToString());
            }
            catch (Exception e)
            {
                file.Errors.Add("Fatal error: " + Environment.NewLine + e.ToString());
            }
            return file;
        }

        public List<Using> ParseUsings(string raw)
        {
            List<Using> ret = new List<Using>();
            string[] spl = raw.Split(new string[] { "using" }, StringSplitOptions.None);

            int curUsingNo = 0;
            foreach (string s in spl)
            {
                int semicolonIndex = s.IndexOf(';');
                if (semicolonIndex >= 0)
                {
                    string statement = s.Substring(0, semicolonIndex).Trim();
                    Console.WriteLine(statement);

                    if (statement.Contains('(') || statement.Contains(')'))
                    {
                        continue;
                    }
                    else
                    {
                        Using usingNode = new Using();
                        if (statement.Contains('='))
                        {
                            usingNode.usingType = UsingType.Alias;
                        }
                        else
                        {
                            usingNode.usingType = UsingType.Namespace;

                            if (Utils.ContainsNonVarCharacters(statement))
                            {
                                file.Warnings.Add(string.Format("Invalid characters are present in the namespace level using defintion no. {0} - \"{1}\"",curUsingNo,statement));
                            }
                        }
                        usingNode.namespaceName = statement;
                        ret.Add(usingNode);
                    }
                }
                curUsingNo++;
            }
            return ret;
        }
    }
}
