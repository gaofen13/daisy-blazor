using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
  public partial class DaisyDropdown
  {
    private string Classname =>
      new ClassBuilder("dropdown")
        .AddClass("dropdown-hover", Hover)
        .AddClass("dropdown-end", AlignsToEnd)
        .AddClass($"dropdown-{DropPosition.ToString().ToLower()}")
        .AddClass(Class)
        .Build();

    private string ContentClassname =>
      new ClassBuilder("dropdown-content bg-base-100 menu shadow")
        .AddClass(ContentClass)
        .Build();

    [Parameter]
    public bool Hover { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? TitleContent { get; set; }

    [Parameter]
    public string? ContentClass { get; set; }

    [Parameter]
    public Position DropPosition { get; set; } = Position.Bottom;

    [Parameter]
    public bool AlignsToEnd { get; set; }
  }
}
