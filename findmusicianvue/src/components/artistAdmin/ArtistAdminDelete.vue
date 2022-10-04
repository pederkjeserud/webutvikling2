<template>
    
    <header>
        <h3>Slett artist</h3>
    </header>

    <section class="card delete-artist">
        <div>
            <label class="form-label" for="">Id</label>
            <input v-model="id" type="text">
            <button class="btn btn-secondary" @click="getArtistById">Hent artist</button>
        </div>
        <h4>Id: {{ id }}</h4>
        <h5>Navn: {{ name }}</h5>
        <p>Instrument: {{ instrument }}</p>
        <p>Timepris: {{ pricePerHour }}</p>
        <img :src="`https://localhost:5001/images/${image}`">
        <p>Bildenavn: {{ image }}</p>
        <div>
            <input class="btn btn-danger" @click="deleteArtist" type="button" value="Slett artist">
        </div>
    </section>


</template>

<script>
import { reactive, toRefs } from 'vue'
import axios from 'axios'

export default {
    setup() {
        
        const artistObject = reactive( { id: "", name: "", instrument: "", pricePerHour: "", image: "" } );

        const getArtistById = () => {
            axios(`https://localhost:5001/artist/${artistObject.id}`)
                .then( response => {

                    artistObject.name = response.data.name;
                    artistObject.instrument = response.data.instrument;
                    artistObject.pricePerHour = response.data.pricePerHour;
                    artistObject.image = response.data.image;

                    console.log( response.data );
                } )
        }

        // Etter å ha hentet inn artisten ved hjelp av id, blir feltene fylt inn og artistObject fylt med verdiene
        // Deretter opprettes det et nytt objekt som skal sendes med til controller og sletter objektet (artisten)

        const deleteArtist = () => {

            const deletedArtist = {
                id: parseInt( artistObject.id ),
                name: artistObject.name,
                instrument: artistObject.instrument,
                pricePerHour: parseInt( artistObject.pricePerHour ),
                image: artistObject.image 
            }

            axios.delete( `https://localhost:5001/artist/${deletedArtist.id}`, deletedArtist )
                
            console.log( deletedArtist );

        }

        return {
            getArtistById,
            ...toRefs ( artistObject ),
            deleteArtist
        }
    },
}
</script>