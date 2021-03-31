<div class="dockPanel">

  <div class="dockPanelTop" class:hidden="{enableTop == false}">
    <slot name="top"/>
  </div>
  
  <div class="dockPanelLeft" class:hidden="{enableLeft == false}">
    <slot name="left"/>
  </div>  
  
  <div class="dockPanelCenter" class:hidden="{enableCenter == false}">
    <slot name="center"/>
  </div>
  
  <div class="dockPanelRight" class:hidden="{enableRight == false}">
    <slot name="right"/>
  </div>
  
  <div class="dockPanelBottom" class:hidden="{enableBottom == false}">
    <slot name="bottom"/>
  </div>

</div>

<style>

  .dockPanel {
    display: grid;
    grid-template: auto 1fr auto / auto 1fr auto;
    height: 100%;
  }

  .dockPanelTop {
		grid-column: 1 / 4;
	}

	.dockPanelLeft {
		grid-column: 1 / 2;
	}

	.dockPanelCenter {
		grid-column: 2 / 3;
	}

  .dockPanelRight {
    grid-column: 3 / 4;
  }

	.dockPanelBottom {
		grid-column: 1 / 4;
    
	}

  .hidden {
    display: none;
  }

</style>

<script lang="ts">
  export let enableTop: boolean = true;
  export let enableLeft: boolean = true;
  export let enableCenter: boolean = true;
  export let enableRight: boolean = true;
  export let enableBottom: boolean = true;

  $: console.log(enableBottom);
</script>