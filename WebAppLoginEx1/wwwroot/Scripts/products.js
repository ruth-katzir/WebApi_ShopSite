
let products = [];
let checkedCategories = [];
let cart = [];

function addToCart(newProduct) {
    const index = cart.findIndex(product => product.id == newProduct.id)
    if (index < 0) {
        console.log(index);
        cart.push({ ...newProduct, 'count': 1 });
    }
    else {
        cart[index].count += 1;
    }
    document.getElementById("ItemsCountText").innerText = parseInt(document.getElementById("ItemsCountText").innerText) + 1;
    localStorage.setItem('cart', JSON.stringify(cart));
}

function TrackLinkID() {
    window.location.href = "update.html";
}

function drawProducts(data) {
    data.forEach(product => {
        var temp = document.getElementById("temp-card");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("h1").innerText = product.name;
        clon.querySelector("img").src = `../pictures${product.img}`;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        clon.querySelector("Button").addEventListener('click', (e) => {
            addToCart(product);
        });
        document.getElementById("PoductList").appendChild(clon);
    })
}

function drawCategories(data) {
    console.log("drawCategories");
    console.log(data);
    data.forEach(category => {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("input").id = category.id;
        clon.querySelector("input").addEventListener('click', (e) => {
            search(e.target.id);
        });
        clon.querySelector("input").value = category.name;
        clon.querySelector("label").for = category.name;
        clon.querySelector(".OptionName").innerText = category.name;
        clon.querySelector(".Count").innerText = (products.filter(product => product.categoryId == category.id)).length;
        document.getElementById("categoryList").appendChild(clon);
    })
}


async function getProducts() {
    const response = await fetch(
        `/api/products`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        products = data;
        drawProducts(data);
    }
}

async function getCategories() {
    console.log("getCategories");
    const response = await fetch(
        `/api/categories`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("categories are not exists");
    }
    else {
        const data = await response.json();
        drawCategories(data);
    }
}

function getLocalStoregeCart() {
    let cartFromLocalStorege = JSON.parse(localStorage.getItem('cart')) || [];
    cart = cartFromLocalStorege;
    document.getElementById("ItemsCountText").innerText = cart.length;
    console.log("cartFromLocalStorege ", cartFromLocalStorege);
}

async function atLoad() {
    await getProducts();
    await getCategories();
    getLocalStoregeCart();
}

document.addEventListener("load", atLoad());

function cleanScreen() {
    document.getElementById("PoductList").innerHTML = '';
}


async function search(id) {
    if (id != null) {
        const ind = checkedCategories.findIndex(category => category == id);
        if (ind < 0) {
            checkedCategories.push(id);
        }
        else {
            checkedCategories = checkedCategories.filter(category => category != id);
        }
    }
    cleanScreen();
    checkedCategories = checkedCategories.filter(category => category != null);
    const desc = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;

    const categoriesUrl = checkedCategories.length > 0 ? `&categoryId=${checkedCategories.join("&categoryId=")}` : '';
    const response = await fetch(
        `/api/products/search?desc=${desc}&minPrice=${minPrice}&maxPrice=${maxPrice} ${categoriesUrl}`,
        {
            headers: {
                'Content-Type': 'application/json ; charest=utf-8'
            }
        }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        products = data;
        drawProducts(data);
    }
}






