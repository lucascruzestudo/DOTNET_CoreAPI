using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Project.Application.Common.Localizers;

public class CultureLocalizer
{
    private readonly IStringLocalizer _localizer;

    public CultureLocalizer(IStringLocalizerFactory factory)
    {
        var assemblyName = new AssemblyName(typeof(CultureLocalizer).GetTypeInfo().Assembly.FullName!);
        _localizer = factory.Create("SharedResources", assemblyName.Name!);
    }

    public LocalizedString Text(string key, params object[] arguments)
    {
        return arguments == null || arguments.Length == 0
            ? _localizer[key]
            : _localizer[key, arguments];
    }
}
