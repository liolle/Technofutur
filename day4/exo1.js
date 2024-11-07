const newAccount = (owner)=> {
    console.log(`New account created for user ${owner.name}\n`);
    return {
        owner: owner,
        balance: 0,
        credit: function (amount) {
            console.log(`new transaction`);
            if (typeof  amount != "number") {
                console.error("Wrong amount type\n")
                return
            }
            this.balance += amount;
            console.log(`${amount} as been credited to your account`)
            console.log(`The new balance is ${this.balance}\n`)
        },
        debit: function (amount) {
            console.log(`new transaction`);
            if (amount > this.balance) {
                console.error("Not enough money left")
                console.log(`You need add ${amount-this.balance} to your balance to validate the transaction\n`)

                return
            }
            this.balance-= amount;
            console.log(`${amount} as been debited from your account`)
            console.log(`The new balance is ${this.balance}\n`)
        },
        toString: function () {
            return `You have ${this.balance} money left in you account\n`
        }

    }

}

const user = {
    name: "John",
    lastName: "Doe",
    age: 26,
}

const account = newAccount(user)

account.credit(500)
console.log(account.toString())
account.debit(97)
console.log(account.toString())

account.debit(800)


