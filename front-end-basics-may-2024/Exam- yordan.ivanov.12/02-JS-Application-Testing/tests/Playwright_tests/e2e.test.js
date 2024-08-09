const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let albumName = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    describe("authentication", () => {
        test('Registration with correct data makes correct api call',async()=>{
            await page.goto(host);
            await page.click("text=Register");
            await page.waitForSelector('form');
            let random = Math.floor(Math.random()*10000);
            user.email = `test${random}@abv.bg`;

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#conf-pass').fill(user.confirmPass);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/register") && response.status() == 200),
                page.click('[type="submit"]')
            ])
            let userData = await response.json();

            expect(response.ok()).toBeTruthy();
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        })
        test('Login with valid data makes correct api call',async()=>{
  
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');

            //act
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/login") && response.status() == 200),
                page.click('[type="submit"]')
            ])
            let userData = await response.json();


            //assert
            expect(response.ok()).toBeTruthy();
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        })
        test('Logout makes correct api call',async()=>{
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //act 
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/users/logout") && response.status() == 204 ),
                page.click('nav >> text=Logout')
            ])

            expect(response.ok()).toBeTruthy();
            await page.waitForSelector('nav >> text=Login')
            expect(page.url()).toBe(host + '/');
        })
    });

    describe("navbar", () => {
        test('Navigation for loggen-in users should see correct nav buttons',async()=>{
            await page.goto(host);

            //act
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');

            //assert
            await expect(page.locator('nav >> text="Home"')).toBeVisible();
            await expect(page.locator('nav >> text="Catalog"')).toBeVisible();
            await expect(page.locator('nav >> text="Search"')).toBeVisible();
            await expect(page.locator('nav >> text="Create Album"')).toBeVisible();
            await expect(page.locator('nav >> text="Logout"')).toBeVisible();

            await expect(page.locator('nav >> text=Login')).toBeHidden();
            await expect(page.locator('nav >> text=Register')).toBeHidden()
        })
        test('Navigation for guest users should see correct anv buttons',async()=>{
            await page.goto(host);

            await expect(page.locator('nav >> text="Home"')).toBeVisible();
            await expect(page.locator('nav >> text="Catalog"')).toBeVisible();
            await expect(page.locator('nav >> text="Search"')).toBeVisible();
            await expect(page.locator('nav >> text="Login"')).toBeVisible();
            await expect(page.locator('nav >> text="Register"')).toBeVisible();

            await expect(page.locator('nav >> text=Create Album')).toBeHidden();
            await expect(page.locator('nav >> text=Logout')).toBeHidden()
        })
    });

    describe("CRUD", () => {
        beforeEach(async () =>{
            await page.goto(host);
            await page.click('text=Login');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('[type="submit"]');
        })
        test('Create album makes correct api call',async()=>{
            await page.click('nav >> text=Create Album');
            await page.waitForSelector("form");

            //act
            let random = Math.floor(Math.random()*10000);
            albumName=`Album ${random}`
            await page.fill("#name", albumName);
            await page.fill('[name="imgUrl"]', "/images/pinkFloyd.jpg");
            await page.fill('[name="price"]', "10");
            await page.fill('[name="releaseDate"]', "12.12.12");
            await page.fill('[name="artist"]', "Random artist");
            await page.fill('[name="genre"]', "Random genre");
            await page.fill('[name="description"]', "Random description");
           
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() == 200 ),
                page.click('[type="submit"]')
            ]);
          
            let eventData = await response.json();

            //assert
            expect(response.ok()).toBeTruthy();

            expect(eventData.name).toEqual(albumName);
            expect(eventData.imgUrl).toEqual("/images/pinkFloyd.jpg");
            expect(eventData.price).toEqual("10");
            expect(eventData.releaseDate).toEqual("12.12.12");
            expect(eventData.artist).toEqual("Random artist")
            expect(eventData.genre).toEqual("Random genre")
            expect(eventData.description).toEqual("Random description");
        })
        test('Edit an album makes correct api call',async()=>{
            await page.click('nav >> text=Search')
            await page.locator('#search-input').fill(albumName)
            await page.click('.button-list >> text=Search')
            
            await page.locator('text=Details').first().click()
            await page.click('text=Edit')
            await page.waitForSelector('form')

            await page.locator('[name="price"]').fill('200')
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() === 200),
                page.click('[type="submit"]')
            ]);
            expect(response.ok()).toBeTruthy()

            let eventData=await response.json()

            expect(eventData.name).toEqual(albumName);
            expect(eventData.imgUrl).toEqual("/images/pinkFloyd.jpg");
            expect(eventData.price).toEqual("200");
            expect(eventData.releaseDate).toEqual("12.12.12");
            expect(eventData.artist).toEqual("Random artist")
            expect(eventData.genre).toEqual("Random genre")
            expect(eventData.description).toEqual("Random description");
        })
        test('Delete album makes correct api call for the owner',async()=>{
            await page.click('nav >> text=Search')
            await page.locator('#search-input').fill(albumName)
            await page.click('.button-list >> text=Search')
            
            await page.locator('text=Details').first().click()
            let [response] = await Promise.all([
                page.waitForResponse(response => response.url().includes("/data/albums") && response.status() === 200),
                await page.click('text=Delete')
            ]);
            expect(response.ok()).toBeTruthy();
        })
    });
});