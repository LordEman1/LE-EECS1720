/*window.onclick = function () {
    document.getElementById("button").onclick = changeText(generateName());
}*/

function changeText(name) {
    x = document.getElementById("mySelect");
    x.options[x.selectedIndex].text = name;
  }


function getRandomInt(min, max) {
  	return Math.floor(Math.random() * (max - min)) + min;
}

function generateName(name){
	var name1 = ["Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller"];

	var name2 = ["Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson"];

	var name = name1[getRandomInt(0, name1.length)] + ' ' + name2[getRandomInt(0, name2.length)];
	
    return name;

}