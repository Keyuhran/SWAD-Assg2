using System;

namespace SWAD_Team4_assignment_2
{
    class Card
    {
        private string cardNo;
        private DateTime expiryDate;
        private string holderName;
    }

    public Card(string cardNo, DateTime expiryDate, string holderName)
    {
        this.cardNo = cardNo;
        this.expiryDate = expiryDate;
        this.holderName = holderName;
    }
    
    public string CardNo
    {
        get { return cardNo; }
        set { cardNo = value; }
    }

    public DateTime ExpiryDate 
    {
        get { return expiryDate; }
        set { expiryDate = value; }
    }

    public string HolderName
    {
        get { return holderName; }
        set { holderName = value; }
    }
}