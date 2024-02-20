document.addEventListener("DOMContentLoaded", () => {
    const paymentList = document.getElementById("taskList");
    const createPaymentForm = document.getElementById("createTaskForm");

    function displayPayments() {
        fetch("https://localhost:44353/api/PaymentDetails") 
            .then(response => {
                if (!response.ok) { throw new Error(`Http error! Status ${response.status}`); }
                return response.json();
            })
            .then(payments => {
                paymentList.innerHTML = "";
                payments.forEach(payment => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Payment Id: ${payment.PaymentId}, UserId: ${payment.UserId}, Car Id: ${payment.CarId}, Payment Method: ${payment.PaymentMethod}, Account Details: ${payment.AccountDetails}, Card Details: ${payment.CardDetails}, Amount: ${payment.Amount}, Transaction Status: ${payment.TransactionStatus}, Transaction Date: ${payment.TransactionDate}`;
                    listItem.classList.add("task-list-item");
                    paymentList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                paymentList.innerHTML = "Error fetching payments";
            });
    }

    createPaymentForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const userId = parseInt(document.getElementById("UserId").value);
        const carId = parseInt(document.getElementById("CarId").value);
        const paymentMethod = document.getElementById("PaymentMethod").value;
        const accountDetails = document.getElementById("AccountDetails").value;
        const cardDetails = document.getElementById("CardDetails").value;
        const amount = document.getElementById("Amount").value;
        const transactionStatus = document.getElementById("TransactionStatus").value;
        const transactionDate = document.getElementById("TransactionDate").value;

        fetch("https://localhost:44353/api/PaymentDetails", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ UserId: userId, CarId: carId, PaymentMethod: paymentMethod, AccountDetails: accountDetails, CardDetails: cardDetails, Amount: amount, TransactionStatus: transactionStatus, TransactionDate: transactionDate })
        })
            .then(response => {
                if (!response.ok) { throw new Error(`Http Error: Status ${response.status}`); }
                return response.json();
            })
            .then(() => {
                createPaymentForm.reset();
                displayPayments();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayPayments();
});
