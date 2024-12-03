using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Extra
{
    enum PhoneType
    {
        samsung,
        nokia,
        iphone,
        lg,
        huawei,

    }

    class Phone
    {
        PhoneType mark;

        public Phone(PhoneType mark){
            this.mark = mark;
        }
    }

    class Personne
    {
        string name;
        string lastname;
        DateTime birth;

        public Personne(string name,string lastname,DateTime birth){
            this.name = name;
            this.lastname = lastname;
            this.birth = birth;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Personne other = (Personne)obj;

            return name.Equals(other.name) && 
                lastname.Equals(other.lastname) && 
                birth.Equals(other.birth);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, lastname, birth);
        }

    }


    abstract class Account
    {
        public Personne user;
        public string number;

        protected double balance { get; private set; }

        public Account(Personne user,string number, double balance){
            this.user = user;
            this.number = number;
            this.balance = balance;
        }


        public static double operator +(Account account1, Account account2){
            return Math.Max(account1.balance,0 )+ Math.Max(account2.balance,0 );
        }

        public static double operator +(double sum, Account account){
            return sum+ Math.Max(account.balance,0 );
        }

        public static double operator +( Account account, double sum){
            return sum+ Math.Max(account.balance,0 );
        }

        protected bool Debit (double amount,double limit =0){
            if(amount <0 || this.balance +limit < amount){
                Console.WriteLine("insufficient balance");
                return false;
            }
            this.balance -= amount;
            return true;
        }

         public virtual bool  Debit(double amount){
            if(amount <0 || this.balance < amount){
                Console.WriteLine("insufficient balance");
                return false;
            }
            this.balance -= amount;
            return true;
        }

        public virtual void Credit(double amount){
            this.balance += amount;
        }

        protected abstract double ComputeInterest();

        public void ApplyInterest(){
            double interest = this.ComputeInterest();
            this.balance += interest;
        }

        public void show(){
            Console.WriteLine($"You have {this.balance} in your account");
        }

        public override string ToString(){
            return $"Account: {this.number}, {this.balance}\n";
        }

    }

    class Courant : Account
    {
   
        private double credit_limit;
        double interest_rate = 0.03;
        double negative_interest_rate = 0.0975;

        public Courant(Personne user,string number, double balance, double credit_limit): base(user, number, balance){
            this.credit_limit = credit_limit;
        }

        public override bool  Debit(double amount){
            return base.Debit(amount,this.credit_limit);
        }

        public override string ToString(){
            return $"Account: {this.number}, {this.balance}, {this.credit_limit}\n";
        }

        protected override double ComputeInterest()
        {
            if(base.balance>=0){
                return this.interest_rate * base.balance;
            }else {
                return this.negative_interest_rate * base.balance;
            }
        }
    }




    class Epargne : Account
    {
        DateTime last_transaction;
        double interest_rate = 0.045;
        public Epargne(Personne user, string number, double balance) : base(user, number, balance)
        {
            this.register();
        }

        public override void Credit(double amount)
        {
            base.Credit(amount);
            this.register();
        }

        public override bool Debit(double amount)
        {
            bool accepted = base.Debit(amount);
            if (accepted) {
                this.register();
            }
            return accepted;
        }

        void register(){
            this.last_transaction = DateTime.Now;
            Console.WriteLine($"Last transaction done: {this.last_transaction}");
        }

        protected override double ComputeInterest()
        {
            return this.interest_rate * base.balance;
        }

        public override string ToString(){
            return $"Account: {base.ToString()} Last transaction done: {this.last_transaction}\n";
        }
    }


    class Bank
    {
        string name;
        List<Account> accounts = new List<Account>();

        public Bank(string name){
            this.name = name;
        }

        public Account? this[string number]{
            get{
                return this.accounts.Find(acc=>acc.number == number);
            }
        }

        public void add(Account ac){
            accounts.Add(ac);
        }

        public void remove(string number){
            accounts.RemoveAll(acc=>acc.number == number);
        }
        
        public double assetsSum(Personne user){
            double sum = 0;
            foreach (Account account in this.accounts)
            {
                if(account.user.Equals(user)){
                    sum += account;
                }
            }
           
            return sum ;
        }

        public void ApplyInterest(){
            foreach (Account acc in this.accounts)
            {
                acc.ApplyInterest();
            }
        }
    }


}

