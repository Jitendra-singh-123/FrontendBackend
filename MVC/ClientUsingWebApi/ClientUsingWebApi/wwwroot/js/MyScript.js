document.addEventListener("DOMContentLoaded", () => {

    const taskList = document.getElementById("taskList");
    const createTaskForm = document.getElementById("createTaskForm");

    function displayTask() {
        fetch("https://localhost:44389/api/Tasks")
            .then(response => {
                if (!response.ok) { throw new Error(`Http error! Status ${response.status}`); }
                return response.json();
            })
            .then(tasks => {
                taskList.innerHTML = "";
                tasks.forEach(task => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Id: ${task.Id}, Title: ${task.Title}, Description: ${task.Description}, DueDate: ${task.DueDate}`;
                    listItem.classList.add("task-list-item");//adding class name to list
                    taskList.appendChild(listItem);
                });
            })
            .catch(error => {
                console.error("Fetch error: ", error);
                taskList.innerHTML = "Error fetching tasks";
            });
    }

    createTaskForm.addEventListener("submit", (e) => {
        e.preventDefault();
        const title = document.getElementById("title").value;
        const description = document.getElementById("description").value;
        const dueDate = document.getElementById("dueDate").value;

        fetch("https://localhost:44389/api/Tasks", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ title, description, dueDate })
        })
            .then(response => {
                if (!response.ok) { throw new Error(`Http Error: Status ${response.status}`); }
                return response.json();
            })
            .then(() => {
                document.getElementById("title").value = "";
                document.getElementById("description").value = "";
                document.getElementById("dueDate").value = "";
                displayTask();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayTask();

});
