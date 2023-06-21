using Settings.Service.Extensions;

namespace Settings.Service.ConfigurationServiceBuilderPlugIns;

public class ConfigurationServiceBuilderVariablePlugIn : IConfigurationServiceBuilderPlugIn
{
    private class WithVariablesValue
    {
        public LinkedList<string> Variables { get; set; }
        public ConfigurationValue Value { get; init; }
    }

    private readonly IConfigurationServiceBuilderPlugIn _next;
    private readonly LinkedList<WithVariablesValue> _withVariablesValue = new();
    private readonly Dictionary<string, string> _allVariables = new();
    private readonly ParamsExtracter _paramsExtracter = new();

    public ConfigurationServiceBuilderVariablePlugIn(IConfigurationServiceBuilderPlugIn next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public void InsertValue(string path, in ConfigurationValue value)
    {
        _allVariables.Add(path, value.Value);

        var variables = _paramsExtracter.GetParams(value.Value);
        if (variables.Count > 0)
        {
            _withVariablesValue.AddLast(new WithVariablesValue()
            {
                Value = value,
                Variables = variables
            });
        }

        _next.InsertValue(path, value);
    }

    public Dictionary<string, object> GetResult()
    {
        ReplaceAllVariables(_withVariablesValue);
        return _next.GetResult();
    }

    private void ReplaceAllVariables(LinkedList<WithVariablesValue> withVariablesValue)
    {
        // На тот случай если в значении переменой содержится другая переменная
        while (withVariablesValue.Count != 0)
        {
            withVariablesValue.ForEach(valInfo =>
            {
                ReplaceVariables(valInfo.Variables, valInfo.Value, _allVariables);

                valInfo.Variables = _paramsExtracter.GetParams(valInfo.Value.Value);
            });

            withVariablesValue =
                new LinkedList<WithVariablesValue>(
                    withVariablesValue.Where(x => x.Variables.Count > 0));
        }
    }

    private void ReplaceVariables(LinkedList<string> variables, ConfigurationValue value,
        IDictionary<string, string> variablesWithValues)
    {
        variables.ForEach(variableName =>
        {
            if (!variablesWithValues.TryGetValue(variableName, out var variableValue))
            {
                throw new Exception($"Не найдено значение переменно {variableName}");
            }

            value.Value = value.Value.Replace(
                string.Concat("${", variableName, "}"),
                variableValue);
        });
    }
}