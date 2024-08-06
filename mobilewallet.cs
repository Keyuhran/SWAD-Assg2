class MobileWallet
{
    private string name;

    private string transcationId;

    public MobileWallet (string name, string transcationId)
    {
        this.name = name;
        this.transcationId = transcationId;
    }

    public string name
    {
        get { return name; }
        set { name = value; }
    }

    public string transcationId
    {
        get { return transcationId; }
        set { transcationId = value; }
    }
}