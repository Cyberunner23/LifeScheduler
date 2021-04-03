<DockPanel enableBottom={false}>
	<div slot="top">
		<SiteHeader></SiteHeader>
	</div>

	<div slot="left">
		LEFT
	</div>

	<div slot="center">
		CENTER
		<Sortable {items} let:item={item} options={{ group: 'shared' }}>
			<div>
				<button> {item} </button>
			</div>
		</Sortable>
		<Sortable items={items2} let:item={item} options={{ group: 'shared' }}>
			<div>
				<button> {item} </button>
			</div>
		</Sortable>
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

	import Sortable from "svelte-sortable";


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