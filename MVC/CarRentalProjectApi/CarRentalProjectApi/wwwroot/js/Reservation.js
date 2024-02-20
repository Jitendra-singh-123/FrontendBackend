document.addEventListener("DOMContentLoaded", () => {
    const reservationList = document.getElementById("taskList"); // Updated list ID to match HTML
    const createReservationForm = document.getElementById("createTaskForm");

    function displayReservations() {
        fetch("https://localhost:44353/api/Reservations") // Updated API endpoint
            .then(response => {
                if (!response.ok) { throw new Error(`Http error! Status ${response.status}`); }
                return response.json();
            })
            .then(reservations => {
                reservationList.innerHTML = "";
                reservations.forEach(reservation => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Reservation Id: ${reservation.ReservationId}, UserId: ${reservation.UserId}, Car Id: ${reservation.CarId}, PickupDateTime: ${reservation.PickupDateTime}, DropoffDateTime: ${reservation.DropoffDateTime}`;
                    listItem.classList.add("task-list-item"); // Adding class name to list
                    reservationList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                reservationList.innerHTML = "Error fetching reservations";
            });
    }

    createReservationForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const userId = document.getElementById("UserId").value;
        const carId = document.getElementById("CarId").value;
        const pickupDateTime = document.getElementById("PickupDateTime").value;
        const dropoffDateTime = document.getElementById("DropoffDateTime").value;

        fetch("https://localhost:44353/api/Reservations", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ UserId: userId, CarId: carId, PickupDateTime: pickupDateTime, DropoffDateTime: dropoffDateTime })
        })
            .then(response => {
                if (!response.ok) { throw new Error(`Http Error: Status ${response.status}`); }
                return response.json();
            })
            .then(() => {
                document.getElementById("UserId").value = "";
                document.getElementById("CarId").value = "";
                document.getElementById("PickupDateTime").value = "";
                document.getElementById("DropoffDateTime").value = "";
                displayReservations();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayReservations();
});
