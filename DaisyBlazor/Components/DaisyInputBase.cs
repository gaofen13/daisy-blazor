using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace DaisyBlazor
{
    public abstract class DaisyInputBase<TValue> : DaisyComponentBase
    {
        protected Type? _nullableUnderlyingType;

        [CascadingParameter]
        protected EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public bool ValidationDisabled { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TValue>>? ValueExpression { get; set; }

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        public ValueTask FocusAsync() => Element.FocusAsync();

        protected EditContext? EditContext { get; set; }

        protected FieldIdentifier FieldIdentifier { get; set; }

        protected virtual TValue? CurrentValue
        {
            get => Value;
            set
            {
                var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    Value = value;
                    ValueChanged.InvokeAsync(value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
            }
        }

        protected string? FieldClass => EditContext?.FieldCssClass(FieldIdentifier);

        public override Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (!ValidationDisabled)
            {
                if (EditContext == null)
                {
                    // This is the first run
                    if (CascadedEditContext != null)
                    {
                        if (ValueExpression == null)
                        {
                            throw new InvalidOperationException(
                                $"{GetType()} requires a value for the 'ValueExpression' " +
                                $"parameter. Normally this is provided automatically when using 'bind-Value'.");
                        }

                        EditContext = CascadedEditContext;
                        FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                        _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));
                    }
                }
                else if (CascadedEditContext != EditContext)
                {
                    // Not the first run

                    // We don't support changing EditContext because it's messy to be clearing up state and event
                    // handlers for the previous one, and there's no strong use case. If a strong use case
                    // emerges, we can consider changing this.
                    throw new InvalidOperationException($"{GetType()} does not support changing the " +
                                                        $"{nameof(EditContext)} dynamically.");
                }
            }

            // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
            return base.SetParametersAsync(ParameterView.Empty);
        }
    }
}
