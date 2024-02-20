document.addEventListener("DOMContentLoaded", () => {
    const taskList = document.getElementById("taskList");
    const createTaskForm = document.getElementById("createTaskForm");

    function displayTask() {
        fetch("https://localhost:44353/api/Admins") // Updated API endpoint
            .then(response => {
                if (!response.ok) { throw new Error(`Http error! Status ${response.status}`); }
                return response.json();
            })
            .then(admins => {
                taskList.innerHTML = "";
                admins.forEach(admin => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Id: ${admin.AdminId}, Name: ${admin.Username}, Role: ${admin.Role}`;
                    listItem.classList.add("task-list-item"); // Adding class name to list
                    taskList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                taskList.innerHTML = "Error fetching admins"; // Updated error message
            });
    }

    createTaskForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const name = document.getElementById("Name").value; // Updated input ID
        const password = document.getElementById("Password").value; // Updated input ID
        const role = document.getElementById("Role").value; // Updated input ID

        fetch("https://localhost:44353/api/Admins", { // Updated API endpoint
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ Username: name, Password: password, Role: role }) // Updated field names
        })
            .then(response => {
                if (!response.ok) { throw new Error(`Http Error: Status ${response.status}`); }
                return response.json();
            })
            .then(() => {
                document.getElementById("Name").value = "";
                document.getElementById("Password").value = "";
                document.getElementById("Role").value = "";
                displayTask();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayTask();
});
