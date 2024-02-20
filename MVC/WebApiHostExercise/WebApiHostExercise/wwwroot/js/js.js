document.addEventListener("DOMContentLoaded", () => {
    const playerList = document.getElementById("playerList");
    function displayPlayers() {
        fetch("https://localhost:44313/api/Players")
            .then(response => {
                if (!response.ok) { throw new Error(`HTTP error! Status ${response.status}`); }
                return response.json();
            })
            .then(players => {
                playerList.innerHTML = "";
                players.forEach(player => {
                    const listItem = document.createElement("li");
                    listItem.textContent = `Id: ${player.pId}, Name: ${player.pName}, Country: ${player.pCountry}, Type: ${player.pType}`;
                    playerList.appendChild(listItem);

                });
            }).catch(error => {
                console.error("Fetch error: ", error);
                playerList.innerHTML = "Error fetching tasks";
            });
    }
    displayPlayers();

});