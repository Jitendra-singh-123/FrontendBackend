document.addEventListener("DOMContentLoaded", () => {
    const taskList = document.getElementById("taskList");
    const createTaskForm = document.getElementById("createTaskForm");

    function displayTask() {
   
        fetch("https://localhost:44353/api/CarListings")
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Http error! Status ${response.status}`);
                }
                return response.json();
            })
            .then(tasks => {
                taskList.innerHTML = "";
                tasks.forEach(task => {
                    const listItem = document.createElement("li");

                    // Create text content
                    const textContent = `Car Id: ${task.CarId}, Make: ${task.Make}, Model: ${task.Model}, Location: ${task.Location}, Status: ${task.Status}, DailyPrice : ${task.DailyPrice}`;

                    // Set text content to list item
                    listItem.textContent = textContent;

                    // Create image element
                    const image = document.createElement("img");
                    image.src = task.ImageUrl;
                    image.alt = "Car Image";

                    // Append image to list item
                    listItem.appendChild(image);

                    // Add class to list item
                    listItem.classList.add("task-list-item");

                    // Append list item to task list
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
        const make = document.getElementById("Make").value;
        const model = document.getElementById("Model").value;
        const location =  document.getElementById("Location").value;
        const specifications = document.getElementById("Specifications").value;
        const price = document.getElementById("DailyPrice").value;
        const availableFrom = document.getElementById("AvailableFrom").value;
        const availableTo = document.getElementById("AvailableTo").value;
        const imageUrl = document.getElementById("ImageUrl").value;
        const carPlateNumber = document.getElementById("CarPlateNumber").value;
        const status = document.getElementById("Status").value;

        fetch("https://localhost:44353/api/CarListings", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ Make: make, Model: model, Location: location, specifications: specifications, DailyPrice: price, AvailableFrom: availableFrom, AvailableTo: availableTo, ImageUrl: imageUrl, CarPlateNumber: carPlateNumber, Status: status })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Http Error: Status ${response.status}`);
                }
                return response.json();
            })
            .then(() => {
                
                createTaskForm.reset();
                displayTask();
            })
            .catch(error => {
                console.error("Fetch Error: ", error);
            });
    });

    displayTask();
});
