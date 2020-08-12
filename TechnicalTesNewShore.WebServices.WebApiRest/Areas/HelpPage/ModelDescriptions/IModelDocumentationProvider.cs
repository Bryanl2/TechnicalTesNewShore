using System;
using System.Reflection;

namespace TechnicalTesNewShore.WebServices.WebApiRest.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}