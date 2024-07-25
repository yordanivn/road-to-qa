function solve(string, count) {
    function repeat(string, count) {
        let newString = "";
        for (let i = 0; i < count; i++) {
            newString += string;
        }
        return newString;
    }
    let newString = repeat(string, count);
    console.log(newString)
}

solve('a', 3);