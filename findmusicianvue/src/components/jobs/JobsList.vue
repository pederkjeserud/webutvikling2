<template>
    
    <header>
        <h1>Oppdrag</h1>
    </header>

    <div>

        <input 
            class="form-control" 
            id="user-input" 
            type="text" 
            v-model="searchInput" 
            placeholder="Søk"
        >
        <input class="btn btn-primary" type="button" value="Søk" @click="searchByDescription">

        <input type="button" class="btn btn-secondary" value="Tilbakestill" @click="resetSearch">

    </div>

    <section>
        <div class="row">
            <jobs-item
                class="col-lg-4 col-md-6 col-sm-8"
                v-for="( jobs, i ) in jobList"
                :key="i"
                :id="jobs.id"
                :title="jobs.title"
                :eventType="jobs.eventType"
                :maxPrice="jobs.maxPrice"
                :description="jobs.description"
                :name="jobs.name"
                :email="jobs.email"
                :phoneNumber="jobs.phoneNumber"
            ></jobs-item>
        </div>   
    </section>

</template>

<script>
import axios from 'axios'
import JobsItem from './JobsItem'
import { reactive, toRefs, ref } from 'vue'


export default {
    setup() {

        const searchInput = ref("");

        const jobs = reactive({ jobList: [] });

        axios("https://localhost:5001/event")
            .then( response => {
                jobs.jobList = response.data;
            } )

        // Samme som i Artist, men her søker man etter ord som finnes i description.

        const searchByDescription = () => {

            axios(`https://localhost:5001/event/getbydescription/${searchInput.value}`)
                .then( response => {
                jobs.jobList = response.data;
            } )
        }

        const resetSearch = () => {
            axios("https://localhost:5001/event")
                .then( response => {
                jobs.jobList = response.data;
            } )

           searchInput.value = "";
        }


        return { 
            ...toRefs( jobs ),
            searchInput,
            searchByDescription,
            resetSearch
        }
    },

    components: { JobsItem }
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