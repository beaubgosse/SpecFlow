﻿using System;
using System.Text.RegularExpressions;

namespace TechTalk.SpecFlow.Generator
{
    public class TestHeaderWriter : ITestHeaderWriter
    {
        static private readonly Regex generatorVersionRe = new Regex(@"<auto-generated>.*SpecFlow Generator Version:\s*(?<ver>\d+\.\d+\.\d+\.\d+).*</auto-generated>", RegexOptions.Singleline);
        static private readonly Regex versionRe = new Regex(@"<auto-generated>.*SpecFlow Version:\s*(?<ver>\d+\.\d+\.\d+\.\d+).*</auto-generated>", RegexOptions.Singleline);

        public Version DetectGeneratedTestVersion(string generatedTestContent)
        {
            var match = generatorVersionRe.Match(generatedTestContent);

            if (!match.Success)
                match = versionRe.Match(generatedTestContent);

            if (match.Success)
                return new Version(match.Groups["ver"].Value);

            return null;
        }
    }
}