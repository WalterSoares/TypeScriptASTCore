using System.Linq;
using TypeScriptASTCore.Core.Types;

namespace TypeScriptAST
{
    class Program
    {
        static void Main(string[] args)
        {
            var tsContent = @"



class People implements IPeople {name: string;constructor(name: string) {
                                    this.name = name;
                                }

                                anyNumber(): number {
                                    return 10;
                                }

                                anyNumber2(): number {
                                    return 10;
                                }
                                }

";
            var ast = new TypeScriptASTCore.Core.TypeScriptAST(tsContent);
            var classDeclaration = ast.OfKind(SyntaxKind.ClassDeclaration).FirstOrDefault();
            var className = classDeclaration?.IdentifierStr;
            var interfaces = classDeclaration?.OfKind(SyntaxKind.HeritageClause).FirstOrDefault();
            var methods = classDeclaration?.OfKind(SyntaxKind.MethodDeclaration).ToList();
            var constructors = classDeclaration?.OfKind(SyntaxKind.Constructor).ToList();
            var classDefinitions = classDeclaration.Children;

            System.Console.WriteLine(className);

            //foreach (var classDefinition in classDefinitions)
            //{
            //    var propertyDeclaration = classDefinition as PropertyDeclaration;
            //    var constructorDeclaration = classDefinition as ConstructorDeclaration;
            //    var methodDeclaration = classDefinition as MethodDeclaration;
            //    var heritageClause = classDefinition as HeritageClause; // interfaces

            //    if (propertyDeclaration != null)
            //    {
            //        var propertyName = propertyDeclaration.IdentifierStr;
            //    }

            //    if (constructorDeclaration != null)
            //    {
            //        var propertyName = constructorDeclaration.IdentifierStr;
            //    }

            //    if (methodDeclaration != null)
            //    {
            //        var propertyName = methodDeclaration.IdentifierStr;
            //    }
            //}
        }
    }
}