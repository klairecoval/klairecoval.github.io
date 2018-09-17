//1 initialize search term as an empty string
let displayTerm = "";

//2  main function
function getData() {
    //add constants
    const GIPHY_URL = "https://api.giphy.com/v1/gifs/search?";
    const GIPHY_KEY = "BVPf1N4FwsXGSi2K8gFjlIRscncQb55f";
    
    //create url variable
    let url = GIPHY_URL + "api_key=" + GIPHY_KEY;
    
    //create display terms with query selector
	displayTerm = document.querySelector('#searchterm').value;
    
    //create variable populated with trim method
    let term = displayTerm.trim();
    
    //create url-friendly version of url without spaces or special characters
    term = encodeURIComponent(term);
    
    //If there's no term to search, then bail out of the function 
    if(term.length < 1) return;
    
    //concatenate term to end of url string 
    url = url + "&q=" + term; 
    
    //retrieve limit element and add it to end of url string 
    let limit = document.getElementById("limit").value;
    url = url + "&limit=" + limit;
    
    //Update the page to show the search term
    document.getElementById('content').innerHTML.replace("<strong>Searching for " + displayTerm + "</strong>");

    //write resulting url to console
    console.log(url);
    
    console.log("getData() called");
	
	console.log(jQuery);
	console.log($); // $ is an alias to the jQuery object
	
	$.ajax({
		dataType: "json",
		url: url,
		data: null,
		success: jsonLoaded // the callback function
	})
	
	//create function to process json
	function jsonLoaded(obj) {
		console.log("obj = " + obj);
		console.log("obj stringified = " + JSON.stringify(obj));
		
		// if there are no results, print a message and return
	if(!obj.data || obj.data.length == 0){
		document.querySelector("#content").innerHTML = `<p><em>No results found for '${displayTerm}'</em></p>`;
		$("#content").fadeIn(500);
		return; // Bail out
	}
		
    /* If there is an array of results, loop through them, and create new elements in the HTML to display each of them. */

    let results = obj.data
    console.log("results.length = " + results.length);
    let bigString = "<p><em>Here are " + results.length + " results for '" + displayTerm + "'</em></p>";
		
    for (let i=0;i<results.length;i++){
        let result = results[i];
        let smallURL = result.images.fixed_width_small.url;
        let url = result.url;
        if (!smallURL) smallURL = "images/no-image-found.png";
        
        // ES6 String Templating
        var line = `<div class='result'><a target='_blank' href='${url}'><img src='${smallURL}' title= '${result.id}' />`;
        line += `<br />View on Giphy</a></div>`;
			
        bigString += line;
	}
		
    document.querySelector("#content").innerHTML = bigString;
	}
}

//3 set up event handler for button click to call function
document.querySelector("#search").onclick = getData;

