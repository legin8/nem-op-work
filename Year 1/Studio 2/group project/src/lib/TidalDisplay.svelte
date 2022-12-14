<script>
  //The API code was taken from the API website, Niwa. It was then edited to fit better standards.
  //"https://api.niwa.co.nz/tides/data?lat=-45.91167&long=170.4833314&numberOfDays=3&datum=MSL&apikey=Fyykjvq2UmQKlbkphCLlKh2AopOiLhxF";

  let localDate;
  let lat = -45.91167;
  let long = 170.4833314;
  const URL = `https://api.niwa.co.nz/tides/data?lat=${lat}&long=${long}&numberOfDays=3&apikey=Fyykjvq2UmQKlbkphCLlKh2AopOiLhxF`;

  //Used from svelte example
  const fetchTides = (async () => {
    const response = await fetch(URL);
    return await response.json();
  })();
</script>

<main>
  <h2>Tidal information for St Clair, Dunedin</h2><br>
  <p>24 HR time</p> <br>
  {#await fetchTides}
    <p>...waiting</p>
  {:then data}
  <div class="grid-container">
    <div class="grid-item-time">Time</div>
    <div class="grid-item-tide">Tide</div>
      {#each data.values as tide}
      <div class="grid-item-time">{new Date(tide.time)}</div>
      <div class="grid-item-tide">{tide.value}</div>
      {/each}
    </div>
  {:catch error}
    <p>An error occurred!</p>
  {/await}
</main>

<style>
  main {
    list-style: none; /*Avoids having bullet points*/
    padding: 10px;
  }
  .grid-container {
    display: grid;
    grid-template-columns: auto auto;
    padding: 10px;
  }
  .grid-item-time,
  .grid-item-tide {
    border: 1px solid gray;
    padding: 20px;
    font-size: 20px;
    text-align: center;
  }
  @media (max-width: 800px) {
    main {
      text-align: left;
    }
  }
</style>
