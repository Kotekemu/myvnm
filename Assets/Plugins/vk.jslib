mergeInto(LibraryManager.library, {
	Hello: function() {
		window.alert("I'm alive!");
	},

	HelloString: function (str) {
		window.alert(Pointer_stringify(str));
	},
})