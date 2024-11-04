let sample_phase = `In the gentle embrace of twilight, as the sun dips below the horizon and paints the sky in hues of orange and lavender, a sense of calm washes over the world, inviting reflection and a moment of serenity amidst the hustle and bustle of daily life, reminding us of the beauty that exists in the transition between day and night.`

console.log(sample_phase)

function removeSpace(word) {
    let output = ""

    for (const char of word){
        if (char !== " "){
            output += char
        }
    }
    return output
}

console.log(removeSpace(sample_phase))