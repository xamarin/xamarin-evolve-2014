(function() {

	// This method is used to color alternating rows in a table when the
	// class "alternate-rows" is applied.
	function altRows(className) {
		var table = document.getElementsByClassName(className);

		for (i = 0; i < table.length; i++) {
			var rows = table[i].getElementsByTagName("tr"); 
			for (r = 0; r < rows.length; r++) {		  
				if (r % 2 == 0) {
					rows[r].className = "evenrowcolor";
				} else {
					rows[r].className = "oddrowcolor";
				}	  
			}
		}
	}

	window.onload=function() {
		altRows("alternate-rows");
	}
})();

// This is used to show/hide code blocks
function toggleCode(btn, id) {
   var e = document.getElementById(id);
   if(e.style.display == 'block') {
	  e.style.display = 'none';
	  btn.innerHTML = "Show Code";
   }
   else {
	  e.style.display = 'block';
	  btn.innerHTML = "Hide Code";
   }
}

// This is used to show/hide text blocks
function toggleBlock(btn, id, showText, hideText) {
   var e = document.getElementById(id);
   if(e.style.display == 'block') {
	  e.style.display = 'none';
	  btn.innerHTML = showText;
   }
   else {
	  e.style.display = 'block';
	  btn.innerHTML = hideText;
   }
}
