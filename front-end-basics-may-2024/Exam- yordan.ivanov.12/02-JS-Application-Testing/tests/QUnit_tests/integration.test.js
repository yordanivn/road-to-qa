const baseUrl = "http://localhost:3030/";

let user = {
    email: "",
    password: "123456"
};

let lastAlbumId = '';
let myAlbum = {
    name: "",
    artist: "Unknown",
    description: "",
    genre: "Random genre",
    imgUrl: "/images/Lorde.jpg",
    price: "15.25",
    releaseDate: "29 June 2024",
}

let token = "";
let userId = "";

QUnit.config.reorder = false;
QUnit.module('user functionality',()=>{
    QUnit.test('registration',async(assert)=>{
        let path = 'users/register';

        let random = Math.floor(Math.random() * 10000);
        let email = `test${random}@abv.bg`;
        user.email = email;

        //act
        let response = await fetch(baseUrl + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        let json = await response.json();

        assert.ok(response.ok);

        assert.ok(json.hasOwnProperty('email'), "email exists");
        assert.equal(json['email'], user.email, 'expexted email');
        assert.strictEqual(typeof json.email, 'string', "email has corect type");

        assert.ok(json.hasOwnProperty('password'), "password exists");
        assert.equal(json['password'], user.password, 'expexted password');
        assert.strictEqual(typeof json.password, 'string', "password has corect type");

        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "password has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exists");
        assert.strictEqual(typeof json.accessToken, 'string', "accessToken has corect type");

        token = json['accessToken'];
        userId = json['_id'];
        sessionStorage.setItem('user', JSON.stringify(user));
    })
    QUnit.test('login',async (assert)=>{
        let path = 'users/login';

        let response = await fetch(baseUrl + path, {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        let json = await response.json();

        assert.ok(response.ok);

        assert.ok(json.hasOwnProperty('email'), "email exists");
        assert.equal(json['email'], user.email, 'expexted email');
        assert.strictEqual(typeof json.email, 'string', "email has corect type");

        assert.ok(json.hasOwnProperty('password'), "password exists");
        assert.equal(json['password'], user.password, 'expexted password');
        assert.strictEqual(typeof json.password, 'string', "password has corect type");

        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "password has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");

        assert.ok(json.hasOwnProperty('accessToken'), "accessToken exists");
        assert.strictEqual(typeof json.accessToken, 'string', "accessToken has corect type");

        token = json['accessToken'];
        userId = json['_id'];
        sessionStorage.setItem('user', JSON.stringify(user));
    })
})
QUnit.module('album functionality',()=>{
    QUnit.test('get all albums',async(assert)=>{
        let path = 'data/albums';
        let queryParams = '?sortBy=_createdOn%20desc&distinct=name';

        let response = await fetch(baseUrl + path + queryParams);
        let json = await response.json();

        assert.ok(response.ok, "Response is ok");
        assert.ok(Array.isArray(json), "response is array");

        json.forEach(jsonData=>{
            assert.ok(jsonData.hasOwnProperty('_ownerId'), "_ownerId exists");
            assert.strictEqual(typeof jsonData._ownerId, 'string', "_ownerId is from correct type");

            assert.ok(jsonData.hasOwnProperty('name'), "name exists");
            assert.strictEqual(typeof jsonData.name, 'string', "name is from correct type");

            assert.ok(jsonData.hasOwnProperty('imgUrl'), "imgUrl exists");
            assert.strictEqual(typeof jsonData.imgUrl, 'string', "imgUrl is from correct type");

            assert.ok(jsonData.hasOwnProperty('price'), "price exists");
            assert.strictEqual(typeof jsonData.price, 'string', "price is from correct type");

            assert.ok(jsonData.hasOwnProperty('releaseDate'), "releaseDate exists");
            assert.strictEqual(typeof jsonData.releaseDate, 'string', "releaseDate is from correct type");

            assert.ok(jsonData.hasOwnProperty('artist'), "artist exists");
            assert.strictEqual(typeof jsonData.artist, 'string', "artist is from correct type");

            assert.ok(jsonData.hasOwnProperty('genre'), "genre exists");
            assert.strictEqual(typeof jsonData.genre, 'string', "genre is from correct type");

            assert.ok(jsonData.hasOwnProperty('description'), "description exists");
            assert.strictEqual(typeof jsonData.description, 'string', "description is from correct type");

            assert.ok(jsonData.hasOwnProperty('_createdOn'), "_createdOn exists");
            assert.strictEqual(typeof jsonData._createdOn, 'number', "_createdOn is from correct type");

            assert.ok(jsonData.hasOwnProperty('_id'), "_id exists");
            assert.strictEqual(typeof jsonData._id, 'string', "_id is from correct type");
        })
    })
    QUnit.test('create album',async (assert)=>{
        let path = 'data/albums';
        let random=Math.floor(Math.random()*10000)
        myAlbum.title=`Random album title${random}`
        myAlbum.description=`Random description ${random}`
        
        let response = await fetch(baseUrl + path, {
            method : 'POST',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(myAlbum)
        });

        assert.ok(response.ok, "successful response");

        let json = await response.json();

        assert.ok(json.hasOwnProperty('_ownerId'), "_ownerId exists");
        assert.strictEqual(typeof json._ownerId, 'string', "_ownerId has corect type");

        assert.ok(json.hasOwnProperty('name'), "name exists");
        assert.equal(json['name'], myAlbum.name, 'expexted name');
        assert.strictEqual(typeof json.name, 'string', "name has corect type");

        assert.ok(json.hasOwnProperty('imgUrl'), "imgUrl exists");
        assert.equal(json['imgUrl'], myAlbum.imgUrl, 'expexted imgUrl');
        assert.strictEqual(typeof json.imgUrl, 'string', "imgUrl has corect type");

        assert.ok(json.hasOwnProperty('price'), "price exists");
        assert.equal(json['price'], myAlbum.price, 'expexted price');
        assert.strictEqual(typeof json.price, 'string', "price has corect type");

        assert.ok(json.hasOwnProperty('releaseDate'), "releaseDate exists");
        assert.equal(json['releaseDate'], myAlbum.releaseDate, 'expexted releaseDate');
        assert.strictEqual(typeof json.releaseDate, 'string', "releaseDate has corect type");

        assert.ok(json.hasOwnProperty('artist'), "artist exists");
        assert.equal(json['artist'], myAlbum.artist, 'expexted artist');
        assert.strictEqual(typeof json.artist, 'string', "artist has corect type");

        assert.ok(json.hasOwnProperty('genre'), "genre exists");
        assert.equal(json['genre'], myAlbum.genre, 'expexted genre');
        assert.strictEqual(typeof json.genre, 'string', "genre has corect type");

        assert.ok(json.hasOwnProperty('description'), "description exists");
        assert.equal(json['description'], myAlbum.description, 'expexted description');
        assert.strictEqual(typeof json.description, 'string', "description has corect type");

    
        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "_createdOn has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");
        lastAlbumId=json._id
    })
    QUnit.test('edit album',async(assert)=>{
        let path = 'data/albums';
        myAlbum.title=`Edited title`
        
        let response = await fetch(baseUrl + path + `/${lastAlbumId}`, {
            method : 'PUT',
            headers : {
                'content-type' : 'application/json',
                'X-Authorization' : token
            },
            body : JSON.stringify(myAlbum)
        });
        assert.ok(response.ok, "successful response");

        let json = await response.json();

        assert.ok(json.hasOwnProperty('_ownerId'), "_ownerId exists");
        assert.strictEqual(typeof json._ownerId, 'string', "_ownerId has corect type");

        assert.ok(json.hasOwnProperty('name'), "name exists");
        assert.equal(json['name'], myAlbum.name, 'expexted name');
        assert.strictEqual(typeof json.name, 'string', "name has corect type");

        assert.ok(json.hasOwnProperty('imgUrl'), "imgUrl exists");
        assert.equal(json['imgUrl'], myAlbum.imgUrl, 'expexted imgUrl');
        assert.strictEqual(typeof json.imgUrl, 'string', "imgUrl has corect type");

        assert.ok(json.hasOwnProperty('price'), "price exists");
        assert.equal(json['price'], myAlbum.price, 'expexted price');
        assert.strictEqual(typeof json.price, 'string', "price has corect type");

        assert.ok(json.hasOwnProperty('releaseDate'), "releaseDate exists");
        assert.equal(json['releaseDate'], myAlbum.releaseDate, 'expexted releaseDate');
        assert.strictEqual(typeof json.releaseDate, 'string', "releaseDate has corect type");

        assert.ok(json.hasOwnProperty('artist'), "artist exists");
        assert.equal(json['artist'], myAlbum.artist, 'expexted artist');
        assert.strictEqual(typeof json.artist, 'string', "artist has corect type");

        assert.ok(json.hasOwnProperty('genre'), "genre exists");
        assert.equal(json['genre'], myAlbum.genre, 'expexted genre');
        assert.strictEqual(typeof json.genre, 'string', "genre has corect type");

        assert.ok(json.hasOwnProperty('description'), "description exists");
        assert.equal(json['description'], myAlbum.description, 'expexted description');
        assert.strictEqual(typeof json.description, 'string', "description has corect type");

    
        assert.ok(json.hasOwnProperty('_createdOn'), "_createdOn exists");
        assert.strictEqual(typeof json._createdOn, 'number', "_createdOn has corect type");

        assert.ok(json.hasOwnProperty('_id'), "_id exists");
        assert.strictEqual(typeof json._id, 'string', "_id has corect type");
        lastAlbumId=json._id
    })
    QUnit.test('delete album',async(assert)=>{
        //arrange
        let path = "data/albums";

        //act
        let response = await fetch(baseUrl + path + `/${lastAlbumId}`, {
            method: "DELETE",
            headers: {
                'X-Authorization' : token
            }
        })

        //assert
        assert.ok(response.ok)
    })
})