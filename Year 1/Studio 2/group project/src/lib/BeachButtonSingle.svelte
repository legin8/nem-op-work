<script>
  // This is the text that is displayed in the button, It can be changed and used repeatedly
  export let buttonText = "Single Beach";
</script>

<!-- This is that HTML code for this component -->
<main class="beachButton1">
  <button>{buttonText}</button>
</main>

<style>
  /* This is applied to the main of this compontent */
  .beachButton1 {
    display: block;
  }
  /* This targets the button itself normally */
  .beachButton1 button {
    border-radius: 20%;
    border: none;
    background-color: lightcyan;
    font-size: 20px;
    padding: 10px;
    box-shadow: 3px 3px 25px #333;
  }

  /* This targets the button when hovering on it */
  .beachButton1 button:hover {
    border: 1px solid #333;
    box-shadow: 2px 2px 20px #333;
  }
</style>