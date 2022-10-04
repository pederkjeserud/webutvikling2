<template>

    <header>
        <h1>Våre artister</h1>
    </header>

    <div>

        <input 
            class="form-control" 
            id="user-input" 
            type="text" 
            v-model="searchInput" 
            placeholder="Søk på instrument"
        >
        <input class="btn btn-primary" type="button" value="Søk" @click="searchByInstrument">

        <input type="button" class="btn btn-secondary" value="Tilbakestill" @click="resetSearch">

    </div>

    <section>
        <div class="row">
            <artist-item
                class="col-lg-4 col-md-6 col-sm-8"
                v-for="( artist, i ) in artistList"
                :key="i"
                :id="artist.id"
                :name="artist.name"
                :image="artist.image"
                :instrument="artist.instrument"
                :pricePerHour="artist.pricePerHour"
            ></artist-item>
        </div>   
    </section>

</template>

<script>
import axios from 'axios'
import ArtistItem from './ArtistItem'
import { reactive, toRefs, ref } from 'vue'


export default {
    setup() {

        const searchInput = ref("");

        const artists = reactive({ artistList: [] });

        axios("https://localhost:5001/artist")
            .then( response => {
                artists.artistList = response.data;
            } )

        // Funksjon som kontakter get-metode med instrument som parameter. Det bruker skriver inn i søkefeltet vil bli sjekket av controller
        // og siden vil kun vise artister som inneholder det bruker har søkt som instrument.

        const searchByInstrument = () => {

            axios(`https://localhost:5001/artist/getbyinstrument/${searchInput.value}`)
                .then( response => {
                artists.artistList = response.data;
            } )
        }

        // Tilbakestiller søket og viser alle artister

        const resetSearch = () => {
            axios("https://localhost:5001/artist")
                .then( response => {
                artists.artistList = response.data;
            } )

           searchInput.value = "";
        }


        return { 
            ...toRefs( artists ),
            searchInput,
            searchByInstrument,
            resetSearch
        }
    },

    components: { ArtistItem }
}
</script>

<style scoped>

#user-input {
    max-width: 300px; 
    margin: auto;
}

.search-btn {
    margin: auto;
}

</style>