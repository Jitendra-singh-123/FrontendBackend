document.addEventListener("DOMContentLoaded", () => {
    const reservationList = document.getElementById("taskList"); // Updated list ID to match HTML
    const createReservationForm = document.getElementById("createTaskForm");

    function displayReservations() {
        fetch("https://localhost:44353/api/Feedbacks") // Updated API endpoint
            .then(response => {
                if (!response.ok) { throw new Error(`Http error! Status ${response.status}`); }
                return response.json();
            })
            .then(reservations => {
                reservationList.innerHTML = "";
                reservations.forEach(feedback => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Feedback Id: ${feedback.FeedbackId}, UserId: ${feedback.UserId}, Car Id: ${feedback.CarId}, Rating: ${feedback.Rating}, ReviewDateTime: ${feedback.ReviewDateTime}`;
                    listItem.classList.add("task-list-item"); // Adding class name to list
                    reservationList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                reservationList.innerHTML = "Error fetching Feedbacks";
            });
    }

    createReservationForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const userId = document.getElementById("UserId").value;
        const carId = document.getElementById("CarId").value;
        const rating = document.getElementById("Rating").value;
        const reviewDateTime = document.getElementById("ReviewDateTime").value;

        fetch("https://localhost:44353/api/Feedbacks", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ UserId: userId, CarId: carId, Rating: rating, ReviewDateTime: reviewDateTime })
        })
            .then(response => {
                if (!response.ok) { throw new Error(`Http Error: Status ${response.status}`); }
                return response.json();
            })
            .then(() => {
                document.getElementById("UserId").value = "";
                document.getElementById("CarId").value = "";
                document.getElementById("Rating").value = "";
                document.getElementById("ReviewDateTime").value = "";
                displayReservations();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayReservations();
});
