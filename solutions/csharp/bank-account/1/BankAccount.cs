public class BankAccount
{
    private bool isOpen;
    private readonly object _lock = new();
    private decimal balance;
    
    public void Open()
    {
        lock (_lock){

            if(isOpen){
                    throw new InvalidOperationException();
                }
            isOpen = true;
        }
    }

    public void Close()
    {
        lock (_lock){

            if(!isOpen){
                    throw new InvalidOperationException(); 
                }

            balance = 0;
            isOpen = false;
        }
    }

    public decimal Balance
    {
        get
        {
            lock (_lock){
                if(!isOpen){
                    throw new InvalidOperationException();
                }
                
                return balance;
            }
        }
    }

    public void Deposit(decimal change)
    {
        lock (_lock){
            if (!isOpen){
                throw new InvalidOperationException();
            }else if(change < 0){
                throw new InvalidOperationException();
            }

            balance += change;
        }
    }

    public void Withdraw(decimal change)
    {
        lock (_lock){
            if (!isOpen){
                throw new InvalidOperationException();
            }

            if(balance < change){
                throw new InvalidOperationException();
            }else if(change <0){
                throw new InvalidOperationException();
            }
            

            balance -= change;
        }
    }
}
