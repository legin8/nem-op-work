// allImgs is an array with the locations that will be filled with pictures in the dom
// I would remove this variable and use it directly in the api call, however I am also using
// it int the fetch request in the per_page property, using the length of the allImgs so I
// Will always get the right amount of images.
let allImgs = document.querySelectorAll(".imgToApi");

// This is the Base url and api key in different consts to make reading the fetch easier to read.
const BASE_URL = "https://api.unsplash.com";
const API_KEY = "cm4Mq6siY-LIWX3qZD3M6SU1t2Z3qoix0v8ObeVJHOc";

// This API call returns the amount of urls needed for the array it's being used on.
fetch(`${BASE_URL}/search/photos?query=coffee&per_page=${allImgs.length}&client_id=${API_KEY}`)
  .then(response => response.json())
  .then(data => {
    allImgs.forEach((img, i) => {
      img.style.backgroundImage = `url(${data.results[i].urls.regular})`;
    });
  });



// This is for the fixed box that you click away, about free shipping for orders over $25
// Without saving anything to a variable as we don't need to do so, I target the div containing the X,
// then target the element that holds the text and the X and remove them from the dom.
document.querySelector(".clickAwayTargetBox").addEventListener("click", e => {
  document.querySelector(".clickAwayBox").remove();
})


// This is used to change the layout in block 6, it's where you click a vertical bar and each one changes what you are,
// being shown, I'm not saving to any variables as they largely aren't needed, trying to keep things simple.
// Each one displays the page in only its way, to change it you have to click on the other Bar.

// This shows the second block
document.querySelector(".blockB").addEventListener("click", e => {
  document.querySelector(".block6Part1").style.display = "none";
  document.querySelector(".block6Part2").style.display = "block";
  document.querySelector(".block6MainBlock").style.gridTemplateColumns = "120px 120px 1fr";
});

// This show the first block
document.querySelector(".blockA").addEventListener("click", e => {
  document.querySelector(".block6Part1").style.display = "block";
  document.querySelector(".block6Part2").style.display = "none";
  document.querySelector(".block6MainBlock").style.gridTemplateColumns = "120px 1fr 120px";
});