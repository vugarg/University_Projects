function getUserName(){
	if(sessionStorage.getItem("username") == null){
		let userName = window.prompt("Please enter username");
		let message;
		if(userName == null || userName == ""){
			message = "Default user Vugar's shopping list";
		} else {
			message = `${userName}'s shopping list`;
		}
		
		var x = document.cookie.split("=")[1];
	if( x == userName){
		restoreTable();
	} else{
		// localStorage.clear();
		document.cookie = `username = ${userName}`;
		localStorage.setItem("username", userName);
		// document.cookie = `username = ${userName}`;
		document.getElementById("message").innerHTML = message;
	}

	}
	document.getElementById("welcome").innerHTML=sessionStorage.getItem("username")+"'s shopping list";
}

// restoreTable();

// if(window.sessionStorage){
// 	if(sessionStorage.getItem("username")===null){
// 		getUserName();
// 	}else{
// 		document.getElementById("welcome").innerHTML=sessionStorage.getItem("username")+"'s shopping list";
// 	}
// }else{
// 	alert("Client does not support Web Storage");
// }


function productHandle(){
	let productName = document.getElementById("productInput").value;
	let productQuantity = document.getElementById("quantityInput").value;
	let entry = {
		name: productName,
		quantity: productQuantity
	};
	if(localStorage.getItem("products") !== null){
		let storedProducts = JSON.parse(localStorage.getItem("products"));
		storedProducts.push(entry);
		localStorage.setItem("products",JSON.stringify(storedProducts));
	}else{
		localStorage.setItem("products",JSON.stringify([entry]));
	}
	refreshTable(productName,productQuantity);
	document.getElementById("productInput").value ="";
	document.getElementById("quantityInput").value ="";
}

function refreshTable(productName, productQuantity){
	let indexNum = JSON.parse(localStorage.getItem("products")).length;
	document.getElementById("listTable").innerHTML+="<tr onclick='removeItem(this)'><td>"+indexNum+"</td><td>"+productName+"</td><td>"+productQuantity+"</td></tr>";
}

function restoreTable(){
	document.getElementById("listTable").innerHTML='<tr onclick="removeItem(this)"><th>No</th><th>Product</th><th>Quantity</th></tr>';
	if(localStorage.getItem("products")!== null){
		let storedProducts = JSON.parse(localStorage.getItem("products"));
		let totalEntries = storedProducts.length;
		for(let i=0;i<totalEntries;i++){
			document.getElementById("listTable").innerHTML+="<tr onclick='removeItem(this)'><td>"+(i+1)+"</td><td>"+storedProducts[i].name+"</td><td>"+storedProducts[i].quantity+"</td></tr>";
		}
	}
}

function removeItem(element){
	if(confirm("Are you sure you want to remove this item from the list?")){
		element.parentNode.removeChild(element);
		let productIndex = parseInt(element.childNodes[0].innerHTML)-1;
		let storedProducts = JSON.parse(localStorage.getItem("products"));
		storedProducts.splice(productIndex,1);
		localStorage.setItem("products",JSON.stringify(storedProducts));
		restoreTable();
	}
}

function logOut(){
	sessionStorage.clear()
	// localStorage.removeItem("username");
	// localStorage.removeItem("products");
	// document.cookie='username=;Max-Age=0';
	location.reload();
}
