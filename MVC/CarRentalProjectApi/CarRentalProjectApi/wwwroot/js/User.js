document.addEventListener("DOMContentLoaded", () => {
    const taskList = document.getElementById("taskList");
    const createTaskForm = document.getElementById("createTaskForm");

    function displayTask() {
        fetch("https://localhost:44353/api/Users")
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Http error! Status ${response.status}`);
                }
                return response.json();
            })
            .then(users => {
                taskList.innerHTML = "";
                users.forEach(user => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Id: ${user.UserId}, First Name: ${user.FirstName}, Last Name: ${user.LastName}, Email: ${user.EmailAddress}, Phone Number: ${user.PhoneNumber}, Address: ${user.Address}, License Number: ${user.LicenseNumber}`;
                    listItem.classList.add("task-list-item");
                    taskList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                taskList.innerHTML = "Error fetching users";
            });
    }

    createTaskForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const firstName = document.getElementById("FirstName").value;
        const lastName = document.getElementById("LastName").value;
        const email = document.getElementById("Email").value;
        const password = document.getElementById("Password").value;
        const phoneNumber = document.getElementById("PhoneNumber").value;
        const address = document.getElementById("Address").value;
        const licenseNumber = document.getElementById("LicenseNumber").value;

        fetch("https://localhost:44353/api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                FirstName: firstName,
                LastName: lastName,
                Email: email,
                Password: password,
                PhoneNumber: phoneNumber,
                Address: address,
                LicenseNumber: licenseNumber
            })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Http Error: Status ${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                document.getElementById("FirstName").value = "";
                document.getElementById("LastName").value = "";
                document.getElementById("Email").value = "";
                document.getElementById("Password").value = "";
                document.getElementById("PhoneNumber").value = "";
                document.getElementById("Address").value = "";
                document.getElementById("LicenseNumber").value = "";
                displayTask();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayTask();
});
