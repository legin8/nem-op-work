<script>
  // Variables for the API
  const BASE_URL = "https://api.openweathermap.org/data/2.5/weather";
  const LAT = -45.91167;
  const LON = 170.4833314;
  const API_KEY = "appid=1869fd75ae772afba31bd15d7d20aa0c";
  
  // Variables for being displayed on the screen
  let WindSock = "/windsock.png" // I got this image from https://www.flaticon.com/free-icon/windsock_32104 it can be changed
  let currentWindDirection = "???";
  let windSpeed;
  let units = ["Km/h", "M/h", "Knots"];
  let km , m, knots;

  // This is for iterating over the units array
  let unitIndex = 0;

  // This is the async fetch call for the api that also sets the windSpeed that displays on the screen
  (async () => {
	const response = await fetch(`${BASE_URL}?lat=${LAT}&lon=${LON}&${API_KEY}`)
  let data = await response.json()
  setWindDirection(data.wind.deg); // This sets the wind direction to be displayed on the screen
  Convert(data.wind.speed); // This converts the data to fill the speed units variables
  windSpeed = Math.round(data.wind.speed); // This sets the first value to be displayed to the screen and rounds it.
	})()

  // This changes the value of unitIndex to move through the units array,
  // Also changes the value of windSpeed for each unitIndex
  let WindSpeedUnitClick = _ => {
    unitIndex++;
    if (unitIndex > 2) unitIndex = 0;
    if (unitIndex === 0) windSpeed = km;
    if (unitIndex === 1) windSpeed = m;
    if (unitIndex === 2) windSpeed = knots;
  }

  // This fills the km, m and knots variables so they are ready for use on the click of the onClick
  let Convert = (x) => {
    km = Math.round(x);
    m = Math.round(x / 1.609344);
    knots = Math.round(0.53996 * x);

  }
  
  // This Sets the wind direction and is called from the api selfcalling method,
  // the value is passed from the api block
  let setWindDirection = x => {
    if (x >= 291 && 340) currentWindDirection = "NW"; // NW
    if (x >= 341 && x <= 360 || x >= 0 && x <= 30) currentWindDirection = "N"; // N
    if (x >= 31 && x <= 70) currentWindDirection = "NE"; // NE
    if (x >= 71 && x <= 110) currentWindDirection = "E"; // E
    if (x >= 111 && x <= 150) currentWindDirection = "SE"; // SE
    if (x >= 151 && x <= 210) currentWindDirection = "S"; // S
    if (x >= 211 && x <= 250) currentWindDirection = "SW"; // SW
    if (x >= 251 && x <= 290) currentWindDirection = "W"; // W
  }
</script>


<main class="Wind windMain">
  <!-- This component is on 2 lines, the top line has the wind direction and a picture of a windsock atm -->
  <div>
    <!-- Top Line -->
    <div class="topLine">
      {currentWindDirection}<img class="windsock" src={WindSock} alt="Windsock">
    </div>
    <!-- Bottom Line -->
    <div on:click={WindSpeedUnitClick}>
      {windSpeed} {units[unitIndex]} (click to change)
    </div>
  </div>
    
</main>

<style>
  /* This sets the component to block, ensuring it isn't inheriting other display properties */
  .windMain {
    display: block;
    
  }

  /* This sets the size of the windsock image */
  .windsock {
    width: 16px;
    padding-left: 6px;
  }
</style>