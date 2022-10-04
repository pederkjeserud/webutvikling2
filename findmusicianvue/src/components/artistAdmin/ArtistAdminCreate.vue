<template>
    
    <header>
        <h3>Legg til ny artist</h3>
    </header>

    <section class="card" >
        <div>
            <label class="form-label" for="">Navn</label>
            <input v-model="name" class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Instrument</label>
            <input v-model="instrument"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Timespris</label>
            <input v-model="pricePerHour"  class="form-control" type="text">
        </div>
        <div>
            <label class="form-label" for="">Velg bilde</label>
            <input @change="setImage" type="file">
            <p>Valgt bilde: {{ image }}</p>
        </div>
        <div>
            <input class="btn btn-primary" @click="postArtist" type="button" value="Large artist">
        </div>
    </section>

</template>

<script>
import axios from 'axios'
import { reactive, toRefs } from 'vue'

export default {
    setup() {

        const artistInput = reactive({ name: "", instrument: "", pricePerHour: "", image: "" });
        const imageObject = new FormData();

        // Putter bildet inn i FormData og setter deretter artistInput til bildenavnet. 

        const setImage = ( e ) => {
            imageObject.append("file", e.target.files[0]);
            artistInput.image = e.target.files[0].name;
        }

        // Gjør axios postkall til controller (post-metoden) for å lagre ny artist i databasen. 
        // Det bruker skriver inn i input-feltet blir da verdiene til artist som blir lagret i databasen.

        const postArtist = () => {

            const newArtist = {
                name: artistInput.name,
                instrument: artistInput.instrument,
                pricePerHour: parseInt( artistInput.pricePerHour ),
                image: artistInput.image
            }

            // Etter ny artist er blitt lastet opp sørger jeg for at bildet også kommer med, ved å kontake UploadImage-metoden som legger det til riktig plass.

            axios.post( "https://localhost:5001/artist/", newArtist )
                .then ( () => {

                    axios({
                        method: "POST",
                        url: "https://localhost:5001/artist/UploadImage/",
                        data: imageObject, 
                        config: { headers: { "Content-Type": "multipart/form-data" } }
                    })

                } )
        }

        return { 
            ...toRefs( artistInput ), 
            setImage, 
            postArtist 
        }
        
    }
}
</script>