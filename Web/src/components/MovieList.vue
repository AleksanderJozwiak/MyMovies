<template>
  <header>
    <h1 class="d-flex justify-content-center">My movies</h1>
    <h5 class="d-flex justify-content-center">Aleksander Jóźwiak</h5>
  </header>
  <div>
    <button id="downloadBtn" class="btn btn-light mr-1" type="button" @click="downloadClick()">
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cloud-arrow-down" viewBox="0 0 16 16">
        <path fill-rule="evenodd" d="M7.646 10.854a.5.5 0 0 0 .708 0l2-2a.5.5 0 0 0-.708-.708L8.5 9.293V5.5a.5.5 0 0 0-1 0v3.793L6.354 8.146a.5.5 0 1 0-.708.708l2 2z"/>
        <path d="M4.406 3.342A5.53 5.53 0 0 1 8 2c2.69 0 4.923 2 5.166 4.579C14.758 6.804 16 8.137 16 9.773 16 11.569 14.502 13 12.687 13H3.781C1.708 13 0 11.366 0 9.318c0-1.763 1.266-3.223 2.942-3.593.143-.863.698-1.723 1.464-2.383zm.653.757c-.757.653-1.153 1.44-1.153 2.056v.448l-.445.049C2.064 6.805 1 7.952 1 9.318 1 10.785 2.23 12 3.781 12h8.906C13.98 12 15 10.988 15 9.773c0-1.216-1.02-2.228-2.313-2.228h-.5v-.5C12.188 4.825 10.328 3 8 3a4.53 4.53 0 0 0-2.941 1.1z"/>
        </svg>
        Download movies
    </button> 
    <table class="table table-striped">
        <thead>
            <tr>
                <th>
                    Id
                </th>
                <th>
                    Title
                </th>
                <th>
                    Director
                </th>
                <th>
                    Year
                </th>
                <th>
                    Rate
                </th>
                <th>
                    <button id="addBtn" class="btn btn-light mr-1 fload-end" data-bs-toggle="modal" data-bs-target="#movieModal" type="button" @click="addClick()">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                        <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                        </svg>
                        Add movie
                    </button> 
                    
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="(mov, index) in movies" v-bind:key="index">
                <td>{{mov.id}}</td>
                <td>{{mov.title}}</td>
                <td>{{mov.director}}</td>
                <td>{{mov.year}}</td>
                <td>{{mov.rate}}</td>
                <td>
                    <button class="btn btn-light mr-1 fload-end" data-bs-toggle="modal" data-bs-target="#movieModal" type="button" @click="editClick(mov)">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                        </svg>
                    </button>
                    <button class="btn btn-light mr-1 fload-end" type="button" @click="deleteClick(mov.id)">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
                            <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
                        </svg>
                    </button>
                </td>
            </tr>
        </tbody>
        </table>
  </div>

  <div class="modal fade" id="movieModal" tabindex="-1" aria-labelledby="addMovie" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="addMovie">{{ modalTitle }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <div class="input-group mb-3">
                <div>
                    <span class="input-group-text">Title</span>
                    <input type="text" class="form-control" v-model="state.title" >
                    <span class="help" v-if="v$.title.$error"> {{ v$.title.$errors[0].$message }}</span>
                </div>
                <div>
                    <span class="input-group-text">Director</span>
                    <input type="text" class="form-control" v-model="state.director">
                </div>  
                <div>
                    <span class="input-group-text">Year</span>
                    <input type="number" class="form-control" v-model="state.year">
                    <span class="help" v-if="v$.year.$error"> {{ v$.year.$errors[0].$message }}</span>
                </div>  
                <div>
                    <span class="input-group-text">Rate</span>
                    <input type="number" class="form-control" v-model="state.rate">
                    <span class="help" v-if="v$.rate.$error"> {{ v$.rate.$errors[0].$message }}</span>
                </div>  
            </div>
            
            <button type="button" @click="createClick()" v-if="id==-1" class="btn btn-light mr-1">
              Create
            </button>
            <button type="button" @click="updateClik()" v-if="id>-1" class="btn btn-light mr-1">
              Update
            </button>
        </div>
        <div class="modal-footer">
        </div>
      </div>
    </div>
</div>
</template>


<script>
import axios from 'axios'
import useValidate from '@vuelidate/core'
import { between, required, maxLength} from '@vuelidate/validators'
import { reactive, computed } from 'vue'

export default {
name: 'MovieList',

setup(){
    const state = reactive({
        title: "",
        director: "",
        year: 0,
        rate: 0,
    })

    const rules = computed(() => {
        return {
            title: {
                required,
                maxLength: maxLength(200),
            },
            year: {
                required,
                between: between(1900, 2200),
            },
            rate: {
                between: between(0, 10),
            }
        }
    })

    const v$ = useValidate(rules, state)

    return {
        state,
        v$,
    }
},

data(){
    return {
        movies:[],
        outsideMovies:[],
        modalTitle:"",
        id: -1,
        
    };
},

methods:{
    refreshData(){
        axios.get("https://localhost:7090/data").then((response)=>{
            this.movies = response.data;
        });
        axios.get("http://localhost:8080/MyMovies").then((response)=>{
            this.outsideMovies = response.data;
        });
    },
    copyCheck(){
        this.refreshData();
        var titles = new Set(this.movies.map(d => d.title));
        var merged = [...this.movies, ...this.outsideMovies.filter(d => !titles.has(d.title))];
        //console.log(merged)
        Array.prototype.diff = function(a) {
            return this.filter(function(i) {return a.indexOf(i) < 0;});
        };
        var diffrence = merged.diff(this.movies);  
        //console.log(diffrence);
        diffrence.forEach(element => {
            axios.post("https://localhost:7090/create", {
                title: element.title,
                director: element.director,
                year: element.year,
                rate: element.rate
            })
        });
    },
    downloadClick() {
        this.copyCheck();
        this.refreshData();
    },
    addClick() {
       this.modalTitle = "Add movie";
       this.id = -1;
       this.state.title = "";
       this.state.director = "";
       this.state.year = 0;
       this.state.rate = 0;
    },
    editClick(mov) {
       this.modalTitle = "Edit movie";
       this.id = mov.id;
       this.state.title = mov.title;
       this.state.director = mov.director;
       this.state.year = mov.year;
       this.state.rate = mov.rate;
    },
    createClick() {
        this.v$.$validate() 
        if (!this.v$.$error) {
            axios.post("https://localhost:7090/create", {
                title: this.state.title,
                director: this.state.director,
                year: this.state.year,
                rate: this.state.rate
            })
            .then(
                alert("Created data"),
                this.refreshData()
            );
        } else {
            alert("Valid form values")
        } 
    },
    updateClik() {
        this.v$.$validate() 
        if (!this.v$.$error) {
            axios.put("https://localhost:7090/update", {
                id: this.id,
                title: this.state.title,
                director: this.state.director,
                year: this.state.year,
                rate: this.state.rate
            })
            .then(
                alert("Updated data"),
                this.refreshData()
            );
        } else {
            alert("Valid form values")
        } 
    },
    deleteClick(id){
        if(!confirm("Are you sure?")){
            return;
        }
        axios.delete("https://localhost:7090/delete?id=" + id)
        .then(
            alert("Deleted data"),
            this.id = -1,
            this.refreshData()
        );
    },
    
},
mounted:function(){
    this.refreshData();
}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#addBtn{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    border: none;
    width: 85%;
    height: 85%;
    border-radius: 5%;
    width: 120px;
    height: 40px;
}
.btn {
    background-color: #4ec1de;
    transition-duration: 0.3s;
}
.btn:hover {
    background-color: gold;
}
header {
    width: 100%;
    height: 150px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background-color: #4ec1de;
}
table, tbody, thead {
    width: 100%;
}
th {
    align-items: center;
}
tr, th {
    display: flex;
    justify-content: center;
    width: 100%;
    height: 60px;
}
td {
    width: 16.7%;
}
.modal-body {
    width: 100%;
}
.input-group {
    display: flex;
    flex-direction: column;
    width: 100%;
}
.input-group > div{
    display: flex;
    height: 100px;
    width: 100%;
}
.input-group > input{
    display: flex;
    font-size: large;
    height: 100px;
    width: 60%;
}
.input-group-text{
    width: 120px;
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: large;
    font-weight: bold;
}
.help {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    font-size: smaller;
    color: darkred;
    width: 20%;
}
#downloadBtn {
    margin: 15px;;
}
</style>
