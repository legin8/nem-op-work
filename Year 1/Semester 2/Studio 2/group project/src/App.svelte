<script>
  import Tides from './lib/TidalDisplay.svelte';
  import Wind from './lib/WindDisplay.svelte';
  import Temperature from './lib/TempDisplay.svelte';
  import Beaches from './lib/Beaches.svelte';
</script>

<main>
  <div class ="WeatherGrid">
  <Temperature/> 
  <Wind/>
  <Tides/>
  
  <p>Look at all the beautiful beaches we have!<p/>
  <Beaches/>
  </div>
</main>

<style>

</style>
