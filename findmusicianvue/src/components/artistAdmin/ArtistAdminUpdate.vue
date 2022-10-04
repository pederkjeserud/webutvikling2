<template>
    
    <header>
        <h3>Oppdater artist</h3>
    </header>

    <section class="card update-artist">


             <div>
                <label class="form-label" for="">Id</label>
                <input v-model="id" type="text">
                <button class="btn btn-secondary" @click="getArtistById">Hent artist</button>
            </div>
            <div>
                <label class="form-label" for="">Navn</label>
                <input v-model="name" class="form-control" type="text">
            </div>
            <div>
                <label class="form-label" for="">Instrument</label>
                <input v-model="instrument" class="form-control" type="text">
            </div>
            <div>
                <label class="form-label" for="">Timepris</label>
                <input v-model="pricePerHour" class="form-control" type="text">
            </div>
            <div>
                <label class="form-label" for="">Bilde</label>
                <input class="form-control-file" @change="setImage" type="file">
            </div>
            <div>
                <input class="btn btn-primary" @click="putArtist" type="button" value="Lagre endring">
            </div>

        
       
    </section>

</template>

<script>
import { reactive, toRefs } from 'vue'
import axios from 'axios'

export default {
    setup() {

        let artistObject = reactive( { id: "", name: "", instrument: "", pricePerHour: "", image: "" } );
        const imageObject = new FormData();
        
        const getArtistById = () => {
            axios(`https://localhost:5001/artist/${artistObject.id}`)
                .then( response => {

                    artistObject.name = response.data.name;
                    artistObject.instrument = response.data.instrument;
                    artistObject.pricePerHour = response.data.pricePerHour;
                    artistObject.image = response.data.image;

                } )
        }

        const setImage = ( e ) => {
            imageObject.append("file", e.target.files[0]);
            artistObject.image = e.target.files[0].name;
        }

        const putArtist = () => {

            const updatedArtist = {
                id: parseInt( artistObject.id ),
                name: artistObject.name,
                instrument: artistObject.instrument,
                pricePerHour: parseInt( artistObject.pricePerHour ),
                image: artistObject.image 
            }

            axios.put( "https://localhost:5001/artist/", updatedArtist )
                .then( () => {
                    
                    axios({
                        method: "POST",
                        url: "https://localhost:5001/artist/UploadImage/",
                        data: imageObject, 
                        config: { headers: { "Content-Type": "multipart/form-data" } }
                    })

                } )

        }

        return { 
            getArtistById,
            ...toRefs( artistObject ),
            setImage,
            putArtist 
        }

    }
}
</script>