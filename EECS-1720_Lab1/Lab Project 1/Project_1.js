const colorEl = document.getElementById("color-changer");
const rotateEl = document.getElementById("rotate");
const rotate3DEl = document.getElementById("rotate3d");

colorEl.addEventListener("input", () => {
    injectCSS(`body {
        background-color: ${colorEl.value}!important;
    }`);
});

rotateEl.addEventListener("input", () => {
    injectCSS(`body {
        transform: rotate(${rotateEl.value}deg)!important;
    }`);
});

rotate3DEl.addEventListener("input", () => {
    injectCSS(`body {
        transform: rotate3d(1,1,1,${rotate3DEl.value}deg)!important;
    }`);
});

function injectCSS(css) {
  chrome.tabs.query({ active: true, currentWindow: true }, ([tab]) => {
    if (!tab) return;
    chrome.scripting.insertCSS({
      css,
      target: { tabId: tab.id },
    });
  });
}


/*
function getRandomInt(min, max) {
  	return Math.floor(Math.random() * (max - min)) + min;
}

function generateName(name){
	var name1 = ["Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller"];

	var name2 = ["Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson"];

	var name = name1[getRandomInt(0, name1.length)] + ' ' + name2[getRandomInt(0, name2.length)];
	
    return name;

}
*/