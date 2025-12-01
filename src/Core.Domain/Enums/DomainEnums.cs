namespace Core.Domain.Enums
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public enum TransactionSource
    {
        Manual,
        Telegram,
        WhatsApp,
        Automatic // From Email/n8n
    }

    public enum RuleType
    {
        DailyLimit,
        MonthlyBudget,
        CategoryLimit,
        SavingsGoal
    }

    public enum RulePeriod
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum RecurrenceFrequency
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }
}
