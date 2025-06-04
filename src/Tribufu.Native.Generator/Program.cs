// Copyright (c) Tribufu. All Rights Reserved.
// SPDX-License-Identifier: UNLICENSED

using CppAst;
using CppAst.CodeGen.Common;
using CppAst.CodeGen.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tribufu.Platform;
using Zio.FileSystems;

namespace Tribufu.Native.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var applicationDirectory = Paths.GetApplicationDirectory();
            var includeDirectory = Path.Combine(applicationDirectory, "..", "sdk-rust", "include");
            var tribufuIncludeDirectory = Path.Combine(includeDirectory, "tribufu");
            List<string> headerDirectories = [includeDirectory, tribufuIncludeDirectory];

            Console.WriteLine(includeDirectory);

            var options = new CSharpConverterOptions()
            {
                DefaultNamespace = "Tribufu.Native",
                DefaultClassLib = "NativeLibrary",
                DefaultOutputFilePath = "./src/Tribufu.Native/NativeLibrary.cs",
                GenerateEnumItemAsFields = false,
                TypedefCodeGenKind = CppTypedefCodeGenKind.NoWrap,
                DefaultDllImportNameAndArguments = "\"tribufu_sdk\"",
            };

            options.IncludeFolders.AddRange(headerDirectories);

            var headerFiles = headerDirectories.SelectMany(dir => Directory.EnumerateFiles(dir, "*.h")).ToList();
            var compilation = CSharpConverter.Convert(headerFiles, options);

            if (compilation.HasErrors)
            {
                foreach (CppDiagnosticMessage message in compilation.Diagnostics.Messages)
                {
                    if (message.Type == CppLogMessageType.Error)
                    {
                        Console.WriteLine(message);
                    }
                }

                return;
            }

            using var fileSystem = new PhysicalFileSystem();
            using var subFileSystem = new SubFileSystem(fileSystem, fileSystem.ConvertPathFromInternal("."));
            var writer = new CodeWriter(new CodeWriterOptions(subFileSystem));

            compilation.DumpTo(writer);
        }
    }
}
