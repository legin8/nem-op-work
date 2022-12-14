<script>
  //variables
  export let currentCelTemp = 0;
  //variable for fahrenheit
  export let currentFahrTemp = 0;

  //variable definitions
  let getTemp = temp => {
    currentCelTemp = temp;
  }

  let getFarTemp = temp => {
    currentFahrTemp = temp;
  }

  //variables linking the api and the key for it
  const BASE_URL = "https://api.openweathermap.org/data/2.5/weather?lat=-45.91167&lon=170.4833314&appid=";
  const URL_KEY = "91ad9904183cdecf45ade0d5f9290afb";

  let list = document.createElement("ul");

  //weather api and display, the forEach loop probably isn't necessary but it works and could be simplified at a later time
  fetch(`${BASE_URL}${URL_KEY}`)
  .then(response => response.json())
  .then(data => {
    data["weather"].forEach(info => {
      let item = document.createElement("li");
      item.innerHTML = info.description;
      item.style.listStyle = "none";
      list.style.padding = '0';
      list.style.margin = '0';
      list.append(item);
    });
    document.querySelector(".appendedText").append(list)
  });

  //temperature api
  fetch(`${BASE_URL}${URL_KEY}`)
  .then(response => response.json())
  .then(data => {
    //calculation of the temperatures, celcius and fahrenheit
    currentCelTemp = data.main.temp - 273.15;

    // @ts-ignore
    currentCelTemp = currentCelTemp.toFixed(1);
    currentFahrTemp = currentCelTemp * 1.8;
    currentFahrTemp += 32;

    // @ts-ignore
    currentFahrTemp = currentFahrTemp.toFixed(1);
  });

  //assigning the varaibles and changing the values
  getTemp(10);

  getFarTemp(50);

</script>

<!--beginning of the html-->
<main>
  <h1>Latest weather information</h1>
    <!--Weather Block that shows the temperature, and the current weather, it then leads into the wind component-->
    <div class ="temperature">
      Current weather:
      <div class="tempAPI">{currentCelTemp}°c ({currentFahrTemp}°F) with </div>
      <div class="appendedText"></div>
    </div>
</main>
      

<style>
  /* styling sheet */
  .temperature{
    font-size: 22px;
    font-weight: bold;
  }

  .tempAPI, .appendedText{
    font-size: 20px;
    font-weight: lighter;
  }

  .tempAPI{
    padding-top: 15px;
  }

  .appendedText{
    padding-bottom: 25px;
  }

  .appendedText::first-letter{
    text-transform: capitalize;
  }

  @media(max-width: 750px){
    .temperature{
      font-size: 16px;
    }

    .tempAPI, .appendedText{
      font-size: 15px;
    }

    .appendedText{
      padding-bottom: 10px;
    }
  }
</style>