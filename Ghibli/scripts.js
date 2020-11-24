// Create a new request variable and assign a new XMLHttpRequest object to it.
var request = new XMLHttpRequest()

//Open a new connection, using the GET request on the URL endpoint
request.open('GET', 'https://ghibliapi.herokuapp.com/films', true)

request.onload = function () {
    //Begin accessing JSON data here
    var data = JSON.parse(this.response)

    if (request.status >= 200 && request.status < 400) {

        data.forEach((movie) => {
            //Log each movie's title
            console.log(movie.title)

            const card = document.createElement('div')
            card.setAttribute('class', 'card')
        })
    } 
    else {
        console.log('error')
    }

}

const app = document.getElementById('root')

const logo = document.createElement('img')
logo.src = 'logo.png'

const container = document.createElement('div')
container.setAttribute('class', 'container')

app.appendChild(logo)
app.appendChild(container)

//Send request
request.send()