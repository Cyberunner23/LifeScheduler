<DockPanel enableBottom={false}>
	<div slot="top">
		<SiteHeader></SiteHeader>
	</div>

	<div slot="left">
		LEFT
	</div>

	<div slot="center">
		CENTER
	</div>

	<div slot="right">
		RIGHT
	</div>

	<div slot="bottom">
		BOTTOM
	</div>
</DockPanel>

<script lang="ts">
	import "./Theme.svelte"
	import SiteHeader from "./Components/SiteHeader.svelte";
	import DockPanel from "./Components/DockPanel.svelte";

	import Sortable from "svelte-sortable"

	let targetElement: Sortable;

    let items = [
        "foo",
        "bar",
        "baz",
    ]

		let items2 = [
        "foo",
        "bar",
        "baz",
    ]

    function onChange() {
        //`items` are mutated
        console.log(items)
    }


</script>